-- phpMyAdmin SQL Dump
-- version 5.0.3
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Czas generowania: 11 Maj 2022, 19:53
-- Wersja serwera: 10.4.14-MariaDB
-- Wersja PHP: 7.4.11

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Baza danych: `library`
--

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `library`
--

CREATE TABLE `library` (
  `Id` int(11) NOT NULL,
  `Authors` varchar(255) NOT NULL,
  `Title` varchar(255) NOT NULL,
  `Release_date` char(10) NOT NULL,
  `ISBN` char(20) NOT NULL,
  `Format` char(3) NOT NULL,
  `Pages` smallint(6) NOT NULL,
  `Description` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Zrzut danych tabeli `library`
--

INSERT INTO `library` (`Id`, `Authors`, `Title`, `Release_date`, `ISBN`, `Format`, `Pages`, `Description`) VALUES
(2, 'AAAAAAAA', 'AAAAAAAAAAA', '00.00.0000', '21-37-21-37', 'A3', 420, 'Totally original description'),
(4, 'bbBBB', 'BBBBBBBBB', '00.00.0000', '21-37-21-37', 'no', 123, 'yes');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `users`
--

CREATE TABLE `users` (
  `username` text NOT NULL,
  `hash` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Zrzut danych tabeli `users`
--

INSERT INTO `users` (`username`, `hash`) VALUES
('root', '$argon2id$v=19$m=16,t=3,p=1$yUrYf2PvTAkcmN1pw0d4ZQ$dSBG1vKHNqK97Swt2dbB7EXyBTWoK7w6uKWM3llbQJk');

--
-- Indeksy dla zrzutów tabel
--

--
-- Indeksy dla tabeli `library`
--
ALTER TABLE `library`
  ADD PRIMARY KEY (`Id`);

--
-- AUTO_INCREMENT dla zrzuconych tabel
--

--
-- AUTO_INCREMENT dla tabeli `library`
--
ALTER TABLE `library`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
