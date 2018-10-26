CREATE TABLE ics_syncentity
(
  primarykey       UUID         NOT NULL
    CONSTRAINT ics_syncentity_pkey
    PRIMARY KEY,
  date             TIMESTAMP    NOT NULL,
  objectprimarykey UUID         NOT NULL,
  objectstatus     VARCHAR(9)   NOT NULL,
  setting          UUID         NOT NULL,
  auditchangepk	   UUID         NULL
);

CREATE INDEX ics_syncentity_isetting
  ON ics_syncentity (setting);

CREATE TABLE ics_syncsystem
(
  primarykey UUID         NOT NULL
    CONSTRAINT ics_syncsystem_pkey
    PRIMARY KEY,
  name       VARCHAR(255) NOT NULL,
  assembly   VARCHAR(255) NOT NULL
);

CREATE TABLE ics_synctype
(
  primarykey UUID         NOT NULL
    CONSTRAINT ics_synctype_pkey
    PRIMARY KEY,
  name       VARCHAR(255) NOT NULL,
  owner      UUID         NOT NULL
    CONSTRAINT ics_synctype_fics_syncsystem_0
    REFERENCES ics_syncsystem
);

CREATE INDEX ics_synctype_iowner
  ON ics_synctype (owner);

CREATE TABLE ics_syncsetting
(
  primarykey   UUID         NOT NULL
    CONSTRAINT ics_syncsetting_pkey
    PRIMARY KEY,
  mappername   VARCHAR(255) NOT NULL,
  observername VARCHAR(255) NOT NULL,
  source       UUID         NOT NULL
    CONSTRAINT ics_syncsetting_fics_synctype_0
    REFERENCES ics_synctype,
  destination  UUID         NOT NULL
    CONSTRAINT ics_syncsetting_fics_synctype_1
    REFERENCES ics_synctype
);

CREATE INDEX ics_syncsetting_isource
  ON ics_syncsetting (source);

CREATE INDEX ics_syncsetting_idestination
  ON ics_syncsetting (destination);

ALTER TABLE ics_syncentity
  ADD CONSTRAINT ics_syncentity_fics_syncsetting_0
FOREIGN KEY (setting) REFERENCES ics_syncsetting;

CREATE TABLE ics_syncsubsetting
(
  primarykey   UUID         NOT NULL
    CONSTRAINT ics_syncsubsetting_pkey
    PRIMARY KEY,
  propertyname VARCHAR(255) NOT NULL,
  subsetting   UUID         NOT NULL
    CONSTRAINT ics_syncsubsetting_fics_syncsetting_0
    REFERENCES ics_syncsetting,
  setting      UUID         NOT NULL
    CONSTRAINT ics_syncsubsetting_fics_syncsetting_1
    REFERENCES ics_syncsetting
);

CREATE INDEX ics_syncsubsetting_isubsetting
  ON ics_syncsubsetting (subsetting);

CREATE INDEX ics_syncsubsetting_isetting
  ON ics_syncsubsetting (setting);


