DROP DATABASE LogDb;
CREATE DATABASE LogDb CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
USE LogDb;
CREATE TABLE `Http`
(
    `Id`                  bigint(20) unsigned                      NOT NULL AUTO_INCREMENT,
    `DbCreatedAt`         datetime(6)                              NOT NULL DEFAULT current_timestamp(6),
    `AppName`             varchar(50) COLLATE utf8mb4_unicode_ci   NOT NULL,
    `Direction`           tinyint(1) unsigned                      NOT NULL,
    `RequestTime`         datetime(6)                              NOT NULL,
    `RequestIp`           varchar(45) COLLATE utf8mb4_unicode_ci   NOT NULL,
    `RequestUri`          varchar(2048) COLLATE utf8mb4_unicode_ci NOT NULL,
    `RequestQueryString`  varchar(1024) COLLATE utf8mb4_unicode_ci NOT NULL,
    `RequestContentType`  varchar(255) COLLATE utf8mb4_unicode_ci  NOT NULL,
    `RequestMethod`       varchar(50) COLLATE utf8mb4_unicode_ci   NOT NULL,
    `RequestBody`         longtext COLLATE utf8mb4_unicode_ci      NOT NULL,
    `RequestCookies`      varchar(4093) COLLATE utf8mb4_unicode_ci NOT NULL,
    `RequestHeader`       varchar(4096) COLLATE utf8mb4_unicode_ci NOT NULL,
    `ResponseTime`        datetime(6)                                       DEFAULT NULL,
    `ResponseBody`        longtext COLLATE utf8mb4_unicode_ci               DEFAULT NULL,
    `ResponseStatusCode`  smallint(6) unsigned                              DEFAULT NULL,
    `ResponseContentType` varchar(255) COLLATE utf8mb4_unicode_ci           DEFAULT NULL,
    `ResponseHeader`      varchar(4096) COLLATE utf8mb4_unicode_ci          DEFAULT NULL,
    PRIMARY KEY (`Id`),
    KEY `idx_RequestTime` (`RequestTime`)
) ENGINE = InnoDB
  DEFAULT CHARSET = utf8mb4
  COLLATE = utf8mb4_unicode_ci;

CREATE TABLE `Program`
(
    `Id`          bigint(20) unsigned                     NOT NULL AUTO_INCREMENT,
    `DbCreatedAt` datetime(6)                             NOT NULL DEFAULT current_timestamp(6),
    `CreatedAt`   datetime(6)                             NOT NULL,
    `AppName`     varchar(50) COLLATE utf8mb4_unicode_ci  NOT NULL,
    `LogLevel`    varchar(50) COLLATE utf8mb4_unicode_ci  NOT NULL,
    `Message`     varchar(200) COLLATE utf8mb4_unicode_ci NOT NULL,
    `Data`        longtext COLLATE utf8mb4_unicode_ci     NOT NULL,
    PRIMARY KEY (`Id`),
    KEY `idx_CreatedAt` (`CreatedAt`)
) ENGINE = InnoDB
  DEFAULT CHARSET = utf8mb4
  COLLATE = utf8mb4_unicode_ci;

CREATE TABLE `Exception`
(
    `Id`          bigint(20) unsigned                    NOT NULL AUTO_INCREMENT,
    `DbCreatedAt` datetime(6)                            NOT NULL DEFAULT current_timestamp(6),
    `CreatedAt`   datetime(6)                            NOT NULL,
    `AppName`     varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
    `ClassName`   varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
    `MethodName`  varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
    `Message`     text COLLATE utf8mb4_unicode_ci        NOT NULL,
    `StackTrace`  longtext COLLATE utf8mb4_unicode_ci    NOT NULL,
    `Content`     mediumtext COLLATE utf8mb4_unicode_ci           DEFAULT NULL,
    PRIMARY KEY (`Id`),
    KEY `idx_CreatedAt` (`CreatedAt`)
) ENGINE = InnoDB
  DEFAULT CHARSET = utf8mb4
  COLLATE = utf8mb4_unicode_ci;
