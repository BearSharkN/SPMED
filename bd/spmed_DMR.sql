USE Medical;
GO

INSERT INTO Clinicas(nomeClinica,cnpj,razaoSocial,horarioAbertura,horarioFechamento)
VALUES ('Clínica 1', '06.587.473/0001-13', 'SP Medical', '08:00', '21:00'),
	   ('Clínica 2', '95.280.042/0001-30', 'SP Medical', '08:00', '21:00');
GO

INSERT INTO TiposUsuarios(tituloTipoUsuario)
VALUES ('Administrador'),
	   ('Médico'),
	   ('Paciente');
GO

INSERT INTO Especialidades(tituloEspecialidade)
VALUES ('Acupuntura'),
	   ('Anestesiologia'),
	   ('Angiologia'),
	   ('Cardiologia'),
	   ('Cirurgia Cardiovascular'),
	   ('Cirurgia da Mão'),
	   ('Cirurgia do Aparelho Digestivo'),
	   ('Cirurgia Geral'),
	   ('Cirurgia Pediátrica'),
	   ('Cirurgia Plástica'),
	   ('Cirurgia Torácica'),
	   ('Cirurgia Vascular'),
	   ('Dermatologia'),
	   ('Radioterapia'),
	   ('Urologia'),
	   ('Pediatria'),
	   ('Psiquiatria');
GO

INSERT INTO Situacao(descricaoSituacao)
VALUES ('Agendada'),
	   ('Realizada'),
	   ('Cancelada');
GO

INSERT INTO Usuarios(idTipoUsuario,email,senha)
VALUES (1, 'adm@adm.com', '123adm'),
	   (2, 'ricardo.lemos@hotmail.com', 'ricardo'),
	   (2, 'roberto.possarle@hotmail.com', 'roberto'),
	   (2, 'helena.strada@hotmail.com', 'helena'),
	   (3, 'ian@hotmail.com', 'leonardo'),
	   (3, 'pedro@hotmail.com', 'pedro'),
	   (3, 'hemilly@hotmail.com', 'hemilly'),
	   (3, 'victoria@hotmail.com', 'victoria'),
	   (3, 'enzo@hotmail.com', 'enzo'),
	   (3, 'paulo@hotmail.com', 'paulo'),
	   (3, 'saulo@hotmail.com.br', 'saulo'),
	   (1, 'teste@teste', 'teste');
GO

INSERT INTO Pacientes(idUsuario,nomePaciente,dataNascimento,telefone,rg,cpf,endereco)
VALUES (5, 'Ian',  '1999/02/02', '(19) 983978289', '18.665.591-3', '202.432.488-65',
	   'Avenida Maria Paliari Cassimiro, 976 - Mogi Guaçu, SP'),
	   
	   (6, 'Pedro', '1999/02/02', '(19) 983978289', '28.665.591-3', '202.431.488-65',
	   'Avenida Maria Paliari Cassimiro, 976 - Mogi Guaçu, SP'),
	   
	   (7, 'Hemilly', '1999/02/02', '(19) 983978289', '38.665.591-3', '202.435.488-65',
	   'Avenida Maria Paliari Cassimiro, 976 - Mogi Guaçu, SP'),
	   
	   (8, 'Victoria', '1999/02/02', '(19) 983978289', '48.665.591-3', '202.430.488-65',
	   'Avenida Maria Paliari Cassimiro, 976 - Mogi Guaçu, SP'),
	   
	   (9, 'Enzo', '1999/02/02', '(19) 983978289', '58.665.591-3', '202.432.483-65',
	   'Avenida Maria Paliari Cassimiro, 976 - Mogi Guaçu, SP'),
	   
	   (10, 'Paulo', '1999/02/02', '(19) 983978289', '68.665.591-3', '202.432.188-65',
	   'Avenida Maria Paliari Cassimiro, 976 - Mogi Guaçu, SP'),
	   
	   (11, 'Saulo', '1999/02/02', '(19) 983978289', '78.665.591-3', '102.432.488-65',
	   'Avenida Maria Paliari Cassimiro, 976 - Mogi Guaçu, SP');
GO

INSERT INTO Medicos(idClinica,idEspecialidade,idUsuario,nomeMedico,crm)
VALUES (1, 2, 2, 'Ricardo Lemos', '1234-0/SP'),
	   (2, 17, 3, 'Roberto Possarle', '5678-2/SP'),
	   (2, 16, 4, 'Helena Strada', '91011-2/SP');
GO

INSERT INTO Consultas(idMedico,idPaciente,idSituacao,dataConsulta,descricao)
VALUES (1, 23, 1, '2021/01/01', 'Consulta 1'),
	   (1, 24, 1, '2021/01/02', 'Consulta 2'),
	   (2, 25, 2, '2021/01/01', 'Consulta 3'),
	   (2, 26, 2, '2021/01/02', 'Consulta 4'),
	   (3, 27, 3, '2021/01/01', 'Consulta 5'),
	   (2, 28, 3, '2021/01/02', 'Consulta 6'),
	   (3, 19, 3, '2021/01/01', 'Consulta 7');








