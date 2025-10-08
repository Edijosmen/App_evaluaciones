-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 05-10-2025 a las 04:05:47
-- Versión del servidor: 10.4.32-MariaDB
-- Versión de PHP: 8.0.30

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `dbevaluacion`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `asignaciones`
--

CREATE TABLE `asignaciones` (
  `AsignacionId` int(11) NOT NULL,
  `EvaluadorId` int(11) NOT NULL,
  `EvaluadoId` int(11) NOT NULL,
  `Estado` varchar(100) DEFAULT NULL,
  `EvaluacionId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `asignaciones`
--

INSERT INTO `asignaciones` (`AsignacionId`, `EvaluadorId`, `EvaluadoId`, `Estado`, `EvaluacionId`) VALUES
(6, 1, 2, '1', 3),
(9, 1, 3, '1', 3),
(10, 1, 5, '1', 3);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `evaluacion`
--

CREATE TABLE `evaluacion` (
  `EvaluacionId` int(11) NOT NULL,
  `nombre` varchar(250) DEFAULT NULL,
  `FInicio` date DEFAULT NULL,
  `Fcierre` date DEFAULT NULL,
  `Descripcion` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `evaluacion`
--

INSERT INTO `evaluacion` (`EvaluacionId`, `nombre`, `FInicio`, `Fcierre`, `Descripcion`) VALUES
(3, 'Colaborador a Lider', '2025-06-21', '2025-06-21', 'Evaluación de competencias de liderazgo y gestión de equipos');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `preguntas`
--

CREATE TABLE `preguntas` (
  `PreguntaId` int(11) NOT NULL,
  `Npregunta` varchar(250) DEFAULT NULL,
  `EvaluacionId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `preguntas`
--

INSERT INTO `preguntas` (`PreguntaId`, `Npregunta`, `EvaluacionId`) VALUES
(10, '1. Respeto,buen trato.', 3),
(11, '2. Es un guia y promueve su desarrollo', 3),
(12, '3. Suministra instrucciones Claras', 3),
(14, '4. Escucha Activamente y realiza retroalimentación', 3),
(15, '5. Reconoce su labor y lo apoya', 3),
(16, '6. Fortalezas de su lider', 3),
(17, '7. Oportunidad de mejoras de su lider', 3);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `respuesta`
--

CREATE TABLE `respuesta` (
  `RespuestaId` int(11) NOT NULL,
  `RespuestaText` varchar(50) DEFAULT NULL,
  `AsignacionId` int(11) NOT NULL,
  `PreguntaId` int(11) NOT NULL,
  `Periodo` int(10) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `usuario`
--

CREATE TABLE `usuario` (
  `idUser` int(11) NOT NULL,
  `proceso` varchar(100) DEFAULT NULL,
  `parque` varchar(50) DEFAULT NULL,
  `cedula` varchar(50) DEFAULT NULL,
  `nombre` varchar(100) DEFAULT NULL,
  `cargo` varchar(50) DEFAULT NULL,
  `grupo` varchar(50) DEFAULT NULL,
  `Rol` varchar(50) DEFAULT NULL,
  `password` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `usuario`
--

INSERT INTO `usuario` (`idUser`, `proceso`, `parque`, `cedula`, `nombre`, `cargo`, `grupo`, `Rol`, `password`) VALUES
(1, 'TIC', 'OFICINA PRINCIPAL', '1124862267', 'EDINSON JOSE MENESES DIAZ', 'ANALISTA TIC', 'ADMINISTRACION OFICINA', 'administrador', '1124862267'),
(2, 'TIC', 'OFICINA PRINCIPAL', '1002094732', 'COBA NARVAEZ CARLOS ANDRES', 'AUXILIAR TIC', 'ADMINISTRACION OFICINA', 'operador', '1002094732'),
(3, 'operaciones', 'DIVER PLAZA', '1019120520', 'AGUILAR GAMBA CLAUDIA LILIANA', 'PROMOTOR DE DIVERSION', 'PROMOTORES', 'CLIENTE', '1234'),
(5, 'operaciones', 'OFICINA CENTRAL', '51743478', 'AGUILAR SALVADOR MAGDA NELLY', 'COORDINADORA ADMIN INMOBILIARI', 'ADMINISTRACION OFICINAS', 'CLIENTE', '1234'),
(6, 'operaciones', 'OFICINA CENTRAL', '1030699552', 'ALBA BARRETO NATALIA', 'TELEMERCADERISTA', 'ADMINISTRACION OFICINAS', 'CLIENTE', '1234'),
(7, 'operaciones', 'SANTAFÉ', '1233901341', 'ALVIS YEPES JESUS HERNEY', 'TECNICO MANTENIMIENTO', 'MANTEMIMIENTO', 'CLIENTE', '1234'),
(8, 'operaciones', 'TITAN', '79649732', 'ARANDA RAMIREZ JORGE HERNANDO', 'TECNICO MANTENIMIENTO', 'MANTEMIMIENTO', 'CLIENTE', '1234'),
(9, 'operaciones', 'OFICINA CENTRAL', '52501235', 'ARANGUREN ARANGUREN ANGELICA MARIA', 'ANALISTA TALENTO HUMANO', 'ADMINISTRACION OFICINAS', 'CLIENTE', '1234'),
(10, 'operaciones', 'OFICINA CENTRAL', '1019107972', 'ARCHILA CASTRO MARIA EUGENIA', 'COORDINADOR(A)TESORERIA', 'ADMINISTRACION OFICINAS', 'CLIENTE', '1234'),
(11, 'operaciones', 'OFICINA CENTRAL', '80093994', 'BARRERA AVILA WILSON JAVIER', 'ANALISTA CONTABLE', 'ADMINISTRACION OFICINAS', 'CLIENTE', '1234'),
(12, 'operaciones', 'CARIBE', '1065373899', 'BARROSO SANTOS GLORIA MARIA', 'COORD.JUNIOR OPERACIONES', 'AMINISTRACION OPERACIONES', 'CLIENTE', '1234'),
(13, 'operaciones', 'SAN RAFAEL', '1023946521', 'BERMUDEZ LOPEZ LAURA CATERINE', 'PROMOTOR DE DIVERSION', 'PROMOTORES', 'CLIENTE', '1234'),
(14, 'operaciones', 'NUESTRO', '1015453184', 'BOHORQUEZ RODRIGUEZ RUBEN DARIO', 'COORDINADOR DE OPERACIONES', 'AMINISTRACION OPERACIONES', 'CLIENTE', '1234'),
(15, 'operaciones', 'OFICINA CENTRAL', '53041448', 'CAICEDO GALINDO KELLY JOHANA', 'DIRECTOR(A) MERCADEO', 'ADMINISTRACION OFICINAS', 'CLIENTE', '1234'),
(16, 'operaciones', 'TERREROS', '1012453776', 'CAICEDO PALADINEZ DAYANA ANDREA', 'PROMOTOR DE DIVERSION', 'PROMOTORES', 'CLIENTE', '1234'),
(17, 'operaciones', 'TERREROS', '1006005953', 'CAMPOS GUTIERREZ KILIAN ORBEY', 'TECNICO MANTENIMIENTO', 'MANTEMIMIENTO', 'CLIENTE', '1234'),
(18, 'operaciones', 'OFICINA CENTRAL', '1014250268', 'CARDENAS ZAPATA INGRID TATIANA', 'ANALISTA JR TALENTO HUMANO', 'ADMINISTRACION OFICINAS', 'CLIENTE', '1234'),
(19, 'operaciones', 'OFICINA CENTRAL', '1018500499', 'CASTRO DIAZ CRISTIAN FABIAN', 'LIDER DE ENTRENAMIENTO', 'ADMINISTRACION OFICINAS', 'CLIENTE', '1234'),
(20, 'operaciones', 'TITAN', '1022440291', 'CEBALLOS ANDAPIÑA DAVID ALFONSO', 'COORD.JUNIOR OPERACIONES', 'AMINISTRACION OPERACIONES', 'CLIENTE', '1234'),
(21, 'operaciones', 'OFICINA CENTRAL', '79978968', 'CHACON PAMPLONA EDISON', 'COORDINADOR TIC', 'ADMINISTRACION OFICINAS', 'CLIENTE', '1234'),
(22, 'operaciones', 'OFICINA CENTRAL', '1002094732', 'COBA NARVAEZ CARLOS ANDRES', 'AUXILIAR TIC', 'ADMINISTRACION OFICINAS', 'CLIENTE', '1234'),
(23, 'operaciones', 'OFICINA CENTRAL', '1069724599', 'GALVIS VARGAS JESSICA STELLA', 'ASISTENTE DE GERENCIA', 'ADMINISTRACION OFICINAS', 'CLIENTE', '1234');

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `asignaciones`
--
ALTER TABLE `asignaciones`
  ADD PRIMARY KEY (`AsignacionId`) USING BTREE,
  ADD KEY `FK_asig_user1` (`EvaluadoId`),
  ADD KEY `EvaluadorId` (`EvaluadorId`),
  ADD KEY `EvaluacionId` (`EvaluacionId`);

--
-- Indices de la tabla `evaluacion`
--
ALTER TABLE `evaluacion`
  ADD PRIMARY KEY (`EvaluacionId`) USING BTREE;

--
-- Indices de la tabla `preguntas`
--
ALTER TABLE `preguntas`
  ADD PRIMARY KEY (`PreguntaId`,`EvaluacionId`) USING BTREE,
  ADD KEY `FK1Pregunta_Eva` (`EvaluacionId`);

--
-- Indices de la tabla `respuesta`
--
ALTER TABLE `respuesta`
  ADD PRIMARY KEY (`RespuestaId`),
  ADD KEY `AsignacionId` (`AsignacionId`),
  ADD KEY `PreguntaId` (`PreguntaId`);

--
-- Indices de la tabla `usuario`
--
ALTER TABLE `usuario`
  ADD PRIMARY KEY (`idUser`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `asignaciones`
--
ALTER TABLE `asignaciones`
  MODIFY `AsignacionId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT de la tabla `evaluacion`
--
ALTER TABLE `evaluacion`
  MODIFY `EvaluacionId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT de la tabla `preguntas`
--
ALTER TABLE `preguntas`
  MODIFY `PreguntaId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=18;

--
-- AUTO_INCREMENT de la tabla `respuesta`
--
ALTER TABLE `respuesta`
  MODIFY `RespuestaId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- AUTO_INCREMENT de la tabla `usuario`
--
ALTER TABLE `usuario`
  MODIFY `idUser` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=24;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `asignaciones`
--
ALTER TABLE `asignaciones`
  ADD CONSTRAINT `FK_asig_user1` FOREIGN KEY (`EvaluadoId`) REFERENCES `usuario` (`idUser`),
  ADD CONSTRAINT `FK_asig_user2` FOREIGN KEY (`EvaluadorId`) REFERENCES `usuario` (`idUser`),
  ADD CONSTRAINT `FK_asignaciones_evaluacion` FOREIGN KEY (`EvaluacionId`) REFERENCES `evaluacion` (`EvaluacionId`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Filtros para la tabla `preguntas`
--
ALTER TABLE `preguntas`
  ADD CONSTRAINT `FK1Pregunta_Eva` FOREIGN KEY (`EvaluacionId`) REFERENCES `evaluacion` (`EvaluacionId`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Filtros para la tabla `respuesta`
--
ALTER TABLE `respuesta`
  ADD CONSTRAINT `FK_respuesta_asignaciones` FOREIGN KEY (`AsignacionId`) REFERENCES `asignaciones` (`AsignacionId`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `FK_respuesta_preguntas` FOREIGN KEY (`PreguntaId`) REFERENCES `preguntas` (`PreguntaId`) ON DELETE NO ACTION ON UPDATE NO ACTION;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
