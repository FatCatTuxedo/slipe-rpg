-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Server version:               10.3.13-MariaDB - mariadb.org binary distribution
-- Server OS:                    Win64
-- HeidiSQL Version:             9.5.0.5196
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;

-- Dumping structure for table mta.custom_handling
CREATE TABLE IF NOT EXISTS `custom_handling` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `vehicle` int(11) DEFAULT NULL,
  `mass` float unsigned DEFAULT NULL,
  `turnmass` float unsigned DEFAULT NULL,
  `dragCoeff` float DEFAULT NULL,
  `CentMassX` float DEFAULT NULL,
  `CentMassY` float DEFAULT NULL,
  `CentMassZ` float DEFAULT NULL,
  `persub` int(11) DEFAULT NULL,
  `tmult` float DEFAULT NULL,
  `tloss` float DEFAULT NULL,
  `tbias` float DEFAULT NULL,
  `gears` int(11) unsigned DEFAULT NULL,
  `maxvel` float unsigned DEFAULT NULL,
  `enga` float DEFAULT NULL,
  `engi` float DEFAULT NULL,
  `dtype` varchar(50) DEFAULT NULL,
  `etype` varchar(50) DEFAULT NULL,
  `breakd` float DEFAULT NULL,
  `breakbias` float DEFAULT NULL,
  `steerlock` float DEFAULT NULL,
  `sfl` float DEFAULT NULL,
  `sd` float DEFAULT NULL,
  `shsd` float DEFAULT NULL,
  `sul` float DEFAULT NULL,
  `sll` float DEFAULT NULL,
  `sfrb` float DEFAULT NULL,
  `sadm` float DEFAULT NULL,
  `sosd` float DEFAULT NULL,
  `cdm` float DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

-- Dumping data for table mta.custom_handling: ~1 rows (approximately)
/*!40000 ALTER TABLE `custom_handling` DISABLE KEYS */;
INSERT IGNORE INTO `custom_handling` (`id`, `vehicle`, `mass`, `turnmass`, `dragCoeff`, `CentMassX`, `CentMassY`, `CentMassZ`, `persub`, `tmult`, `tloss`, `tbias`, `gears`, `maxvel`, `enga`, `engi`, `dtype`, `etype`, `breakd`, `breakbias`, `steerlock`, `sfl`, `sd`, `shsd`, `sul`, `sll`, `sfrb`, `sadm`, `sosd`, `cdm`) VALUES
	(1, 402, 1500, 4000, 1.8, 0, 0.5, -0.1, 85, 0.8, 0.9, 0.5, 5, 200, 12, 5, 'rwd', 'petrol', 11, 0.4, 30, 1.8, 0.12, 0, 0.28, -0.1, 0.5, 0.4, 0.25, 0.5);
/*!40000 ALTER TABLE `custom_handling` ENABLE KEYS */;

-- Dumping structure for table mta.jobs
CREATE TABLE IF NOT EXISTS `jobs` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `title` varchar(255) DEFAULT NULL,
  `type` int(3) DEFAULT NULL,
  `r` int(3) DEFAULT 0,
  `g` int(3) DEFAULT 0,
  `b` int(3) DEFAULT 0,
  `team` varchar(255) DEFAULT NULL,
  `skins` varchar(255) DEFAULT '0,1',
  PRIMARY KEY (`id`),
  UNIQUE KEY `title` (`title`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=latin1;

-- Dumping data for table mta.jobs: ~9 rows (approximately)
/*!40000 ALTER TABLE `jobs` DISABLE KEYS */;
INSERT IGNORE INTO `jobs` (`id`, `title`, `type`, `r`, `g`, `b`, `team`, `skins`) VALUES
	(1, 'L1 Staff', 1, 0, 0, 0, 'Staff', '211,217'),
	(2, 'L2 Staff', 1, 0, 0, 0, 'Staff', '211,217'),
	(3, 'L3 Staff', 1, 0, 0, 0, 'Staff', '211,217'),
	(4, 'L4 Staff', 1, 0, 0, 0, 'Staff', '211,217'),
	(5, 'L5 Staff', 1, 0, 0, 0, 'Staff', '211,217'),
	(6, 'Unemployed', 5, 0, 0, 0, 'Civs', '-1'),
	(7, 'Criminal', 3, 0, 0, 0, 'Criminals', '-1'),
	(8, 'Gangster', 4, 0, 0, 0, 'Gangsters', '-1'),
	(9, 'Helper', 1, 0, 0, 0, 'AuxStaff', '211,217');
/*!40000 ALTER TABLE `jobs` ENABLE KEYS */;

-- Dumping structure for table mta.users
CREATE TABLE IF NOT EXISTS `users` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `username` varchar(50) NOT NULL DEFAULT '0',
  `password` text NOT NULL DEFAULT '0',
  `staff_level` float NOT NULL DEFAULT 0,
  `skin` int(3) NOT NULL DEFAULT 0,
  `money` int(255) NOT NULL DEFAULT 500,
  `bank` int(255) NOT NULL DEFAULT 1000,
  `dim` int(255) NOT NULL DEFAULT 0,
  `int` int(255) NOT NULL DEFAULT 0,
  `x` float NOT NULL DEFAULT 0,
  `y` float NOT NULL DEFAULT 0,
  `z` float NOT NULL DEFAULT 5,
  `rot` float NOT NULL DEFAULT 0,
  `job` varchar(255) NOT NULL DEFAULT 'Unemployed',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

-- Dumping data for table mta.users: ~1 rows (approximately)
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT IGNORE INTO `users` (`id`, `username`, `password`, `staff_level`, `skin`, `money`, `bank`, `dim`, `int`, `x`, `y`, `z`, `rot`, `job`) VALUES
	(1, 'Ariana', '$2y$10$3hYJanQKd5dH/3SUB5U06OY4ZZcUc12Wqhavvcs9KwP2E704eFkj2', 5, 1, 569, 1000, 0, 0, 0, 0, 5, 0, 'Unemployed');
/*!40000 ALTER TABLE `users` ENABLE KEYS */;

-- Dumping structure for table mta.users_items
CREATE TABLE IF NOT EXISTS `users_items` (
  `id` int(255) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) DEFAULT NULL,
  `amount` int(255) DEFAULT NULL,
  `owner` int(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

-- Dumping data for table mta.users_items: ~1 rows (approximately)
/*!40000 ALTER TABLE `users_items` DISABLE KEYS */;
INSERT IGNORE INTO `users_items` (`id`, `name`, `amount`, `owner`) VALUES
	(1, 'Iron', 12, 1);
/*!40000 ALTER TABLE `users_items` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
