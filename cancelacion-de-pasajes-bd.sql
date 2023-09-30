-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 30-09-2023 a las 10:50:09
-- Versión del servidor: 10.4.25-MariaDB
-- Versión de PHP: 8.1.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `cancelacion-de-pasajes-bd`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `clientes`
--

CREATE TABLE `clientes` (
  `IDCliente` int(11) NOT NULL,
  `Nombre` varchar(255) DEFAULT NULL,
  `Apellido` varchar(255) DEFAULT NULL,
  `CorreoElectronico` varchar(255) DEFAULT NULL,
  `Telefono` varchar(15) DEFAULT NULL,
  `SaldoCredito` decimal(10,2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `clientes`
--

INSERT INTO `clientes` (`IDCliente`, `Nombre`, `Apellido`, `CorreoElectronico`, `Telefono`, `SaldoCredito`) VALUES
(1, 'Aaron Pedro', 'Paco Ramos', 'ppacoramos@gmail.com', '981790313', '0.00'),
(2, 'Crow', 'Programmer', 'crow.programmer.0101@gmail.com', '981790313', '10.00');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `pasajes`
--

CREATE TABLE `pasajes` (
  `IDPasaje` int(11) NOT NULL,
  `IDCliente` int(11) DEFAULT NULL,
  `IDViaje` int(11) DEFAULT NULL,
  `FechaCompra` date DEFAULT NULL,
  `EstadoPasaje` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `pasajes`
--

INSERT INTO `pasajes` (`IDPasaje`, `IDCliente`, `IDViaje`, `FechaCompra`, `EstadoPasaje`) VALUES
(1, 1, 1, '2023-09-25', 'activo'),
(2, 1, 2, '2023-09-27', 'activo'),
(3, 2, 3, '2023-09-29', 'activo');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `viajes`
--

CREATE TABLE `viajes` (
  `IDViaje` int(11) NOT NULL,
  `Destino` varchar(255) DEFAULT NULL,
  `FechaSalida` date DEFAULT NULL,
  `HoraSalida` time DEFAULT NULL,
  `PrecioPasaje` decimal(10,2) DEFAULT NULL,
  `CategoriaViaje` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `viajes`
--

INSERT INTO `viajes` (`IDViaje`, `Destino`, `FechaSalida`, `HoraSalida`, `PrecioPasaje`, `CategoriaViaje`) VALUES
(1, 'Japon', '2023-09-30', '06:30:00', '150.50', 'normal'),
(2, 'Japon', '2023-09-30', '10:30:00', '150.50', 'normal'),
(3, 'Japon', '2023-10-01', '06:30:00', '150.50', 'normal');

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `clientes`
--
ALTER TABLE `clientes`
  ADD PRIMARY KEY (`IDCliente`);

--
-- Indices de la tabla `pasajes`
--
ALTER TABLE `pasajes`
  ADD PRIMARY KEY (`IDPasaje`),
  ADD KEY `IDCliente` (`IDCliente`),
  ADD KEY `IDViaje` (`IDViaje`);

--
-- Indices de la tabla `viajes`
--
ALTER TABLE `viajes`
  ADD PRIMARY KEY (`IDViaje`);

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `pasajes`
--
ALTER TABLE `pasajes`
  ADD CONSTRAINT `pasajes_ibfk_1` FOREIGN KEY (`IDCliente`) REFERENCES `clientes` (`IDCliente`),
  ADD CONSTRAINT `pasajes_ibfk_2` FOREIGN KEY (`IDViaje`) REFERENCES `viajes` (`IDViaje`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
