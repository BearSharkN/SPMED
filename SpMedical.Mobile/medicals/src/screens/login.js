import React, { Component } from "react";
import {
  ImageBackground,
  StyleSheet,
  Text,
  TextInput,
  TouchableOpacity,
  View,
} from "react-native";
import AsyncStorage from "@react-native-async-storage/async-storage";

import api from "../services/api";

export default class Login extends Component {
  constructor(props) {
    super(props);
    this.state = {
      email: "",
      senha: "",
      role: ''
    };
  }

  realizarLogin = async () => {
    console.warn(this.state.email + " " + this.state.senha);

    const resposta = await api.post("/login", {
      email: this.state.email,
      senha: this.state.senha,
    });

    const token = resposta.data.token;
    console.warn(token);

    await AsyncStorage.setItem("userToken", token);

    this.props.navigation.navigate("Main");
  };

  render() {
    return (
      <ImageBackground style={StyleSheet.absoluteFillObject}>
        <View style={styles.overlay} />

        <View style={styles.main}>
          <Text style={styles.textoPrincipal}>SPMEDICALS</Text>
          <Text style={styles.paragrafo}>Bem vindo de volta ;)</Text>
          <Text style={styles.inputTexto}>Digite o seu email:</Text>
          <TextInput
            style={styles.inputLogin}
            placeholder="Digite o seu email"
            placeholderTextColor="#A9AEBA"
            keyboardType="email-address"
            onChangeText={(email) => this.setState({ email })}
          />
          <Text style={styles.inputTexto}>Digite a sua senha:</Text>
          <TextInput
            style={styles.inputLogin}
            placeholder="Digite a sua senha"
            placeholderTextColor="#A9AEBA"
            secureTextEntry={true}
            onChangeText={(senha) => this.setState({ senha })}
          />

          <TouchableOpacity
            style={styles.btnLogin}
            onPress={this.realizarLogin}
          >
            <Text style={styles.btnLoginText}>login</Text>
          </TouchableOpacity>
        </View>
      </ImageBackground>
    );
  }
}

const styles = StyleSheet.create({
  overlay: {
    ...StyleSheet.absoluteFillObject,
    backgroundColor: "#7266D8",
  },

  main: {
    width: "100%",
    height: "100%",
    justifyContent: "center",
    alignItems: "center",
    paddingBottom: 20,
  },

  inputLogin: {
    width: 351,
    height: 45,
    borderRadius: 5,
    backgroundColor: "#FFFFFF",
    marginBottom: 30,
    padding: 10,
    fontFamily: "Jaldi",
    fontSize: 15,
    fontWeight: "700",
    fontStyle: "normal",
  },
  textoPrincipal: {
    justifyContent: "center",
    alignItems: "center",
    width: 360,
    height: 60,
    fontFamily: "IBM Plex Mono",
    fontSize: 58,
    fontWeight: "500",
    fontStyle: "normal",
    lineHeight: 70,
    color: "#FFFFFF",
    marginBottom: 10,
  },
  paragrafo: {
    width: 360,
    height: 50,
    fontFamily: "Alatsi",
    fontSize: 30,
    fontWeight: "400",
    fontStyle: "normal",
    lineHeight: 30,
    color: "#FFFFFF",
  },

  inputTexto: {
    width: 200,
    height: 26,
    fontFamily: "Alatsi",
    fontSize: 20,
    fontWeight: "400",
    fontStyle: "normal",
    lineHeight: 20,
    color: "#FFFFFF",
    alignSelf: "stretch",
    paddingLeft: 30,
  },

  btnLogin: {
    alignItems: "center",
    justifyContent: "center",
    width: 184,
    height: 64,
    borderRadius: 8,
    backgroundColor: "#5E56A5",
    shadowColor: "rgba(0, 0, 0, 0.25)",
    shadowOffset: {
      width: 0,
      height: 4,
    },
    borderStyle: "solid",
    borderWidth: 2,
    borderColor: "#FFFF",
    shadowRadius: 200,
    shadowOpacity: 1,
  },

  btnLoginText: {
    textAlign: "center",
    textTransform: "uppercase",
    width: 102,
    height: 38,
    fontFamily: "Alatsi",
    fontSize: 30,
    fontWeight: "400",
    fontStyle: "normal",
    color: "#FFFFFF",
  },
});
