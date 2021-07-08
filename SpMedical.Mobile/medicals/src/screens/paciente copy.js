import React, { Component } from "react";
import {
  StyleSheet,
  Text,
  View,
  FlatList,
  TouchableOpacity,
} from "react-native";
import AsyncStorage from "@react-native-async-storage/async-storage";

import api from "../services/api";

class Paciente extends Component {
  constructor(props) {
    super(props);

    this.state = {
      listaConsultasPaciente: [],
    };
  }

  BuscarMinhasConsultas = async () => {
    const valorToken = await AsyncStorage.getItem("usuario-login");

    let URL = "/consultas/";

    if (jwtDecode(valorToken).role === "2") {
      URL = "/consultas/ConsultasMedico";

    }else if(jwtDecode(valorToken).role === "3") {
      URL = "/consultas/minhasConsultas";
    }

    const resposta = await api.get(URL, {
      headers: {
        'Authorization': 'Bearer ' + valorToken
      },
    });

    const dadosDaApi = resposta.data;

    this.setState({ listaConsultas: dadosDaApi });
  };

  componentDidMount() {
    this.BuscarMinhasConsultas();
  }

  render() {
    return (
      <View style={styles.footer}>
        <Text style={styles.texto}>Olá, {nomePaciente}</Text>
        <Text style={styles.paragrafo}>Consultas</Text>
        <FlatList>

        </FlatList>
      </View>

    );
  }
}

export default Paciente;

const styles = StyleSheet.create({
  footer: {
    ...StyleSheet.absoluteFill,
    width: "100%",
    height: "25%",
    justifyContent: "center",
    alignItems: "stretch",
    backgroundColor: "#7266D8",
  },
  texto: {
    width: 350,
    height: 60,
    fontFamily: "Alatsi",
    fontSize: 30,
    fontWeight: "400",
    fontStyle: "normal",
    color: "#FFFFFF",
    padding: 10
  },
  paragrafo: {
    width: 200,
    height: 38,
    fontFamily: "Alatsi",
    fontSize: 25,
    fontWeight: "400",
    fontStyle: "normal",
    color: "#FFFFFF",
    paddingLeft: 10
  },
});
