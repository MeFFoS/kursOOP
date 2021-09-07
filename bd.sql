-- ----------------------------
-- Table structure for manufacturers
-- ----------------------------
DROP TABLE IF EXISTS `manufacturers`;
CREATE TABLE `manufacturers` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) NOT NULL,
  `address` varchar(255) NOT NULL,
  `phone` varchar(255) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for medicines
-- ----------------------------
DROP TABLE IF EXISTS `medicines`;
CREATE TABLE `medicines` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) NOT NULL,
  `manufacturer` int(11) NOT NULL,
  `price` decimal(10,0) NOT NULL,
  `count` int(11) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for selling
-- ----------------------------
DROP TABLE IF EXISTS `selling`;
CREATE TABLE `selling` (
  `DateSale` varchar(11) NOT NULL,
  `IDMedicine` int(11) NOT NULL,
  `Count` int(11) NOT NULL,
  PRIMARY KEY (`DateSale`,`IDMedicine`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
