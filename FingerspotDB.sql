/*
 Navicat MySQL Data Transfer

 Source Server         : localhost
 Source Server Version : 50614
 Source Host           : localhost
 Source Database       : FingerspotDB

 Target Server Version : 50614
 File Encoding         : utf-8

 Date: 01/07/2015 16:01:44 PM
*/

SET NAMES utf8;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
--  Table structure for `Emp_T`
-- ----------------------------
DROP TABLE IF EXISTS `Emp_T`;
CREATE TABLE `Emp_T` (
  `EmpID` varchar(10) NOT NULL,
  `EmpName` varchar(100) NOT NULL,
  `EmpTemplate` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

SET FOREIGN_KEY_CHECKS = 1;
