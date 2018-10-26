/*Создание таблиц*/

CREATE TABLE ObjectType (

 primaryKey UUID NOT NULL,

 name VARCHAR(255) NULL,
 
 id VARCHAR(25) NULL,

 PRIMARY KEY (primaryKey));


CREATE TABLE Conformity (

 primaryKey UUID NOT NULL,

 pkSource UUID NULL,

 pkDest UUID NULL,

 Source UUID NOT NULL,

 Type UUID NOT NULL,

 PRIMARY KEY (primaryKey));


CREATE TABLE Source (

 primaryKey UUID NOT NULL,

 name VARCHAR(255) NULL,
 
 id VARCHAR(7) NULL,

 PRIMARY KEY (primaryKey));

 ALTER TABLE Conformity ADD CONSTRAINT FK5272232b17c74e5ba56ff8c08580ed6d FOREIGN KEY (Source) REFERENCES Source; 
CREATE INDEX Indexf6d5539988b449c299e6b3952e2d1d92 on Conformity (Source); 

 ALTER TABLE Conformity ADD CONSTRAINT FK4fdd58c8fdc34e5480c63e7848768c49 FOREIGN KEY (Type) REFERENCES ObjectType; 
CREATE INDEX Index544437721fe8418f9e85a7d4880b1a36 on Conformity (Type); 

/*Созданий секций*/

 CREATE OR REPLACE FUNCTION create_partition_and_insert() RETURNS trigger AS
  $$
    DECLARE
      type varchar(25);
	  source varchar(7);
      partition varchar(42);
    BEGIN
      select id into type from ObjectType where primaryKey = NEW.Type;
	  select id into source from Source where primaryKey = New.Source;
      partition := TG_RELNAME || '_' || lower(type) || '_' || lower(source);
      IF NOT EXISTS(SELECT relname FROM pg_class WHERE relname=partition) THEN
        RAISE NOTICE 'A partition has been created %',partition;
        EXECUTE 'CREATE TABLE ' || partition || ' (check (Type = ''' || NEW.Type || ''' and Source = ''' || NEW.Source || ''')) INHERITS (' || TG_RELNAME || ');';
		EXECUTE 'CREATE INDEX ' || partition || '_pkSource on ' || partition || ' (pkSource); ';
      END IF;
      EXECUTE 'INSERT INTO ' || partition || ' SELECT(' || TG_RELNAME || ' ' || quote_literal(NEW) || ').* RETURNING primaryKey;';
      RETURN NULL;
    END;
 	$$ LANGUAGE plpgsql;

 create trigger conformity_insert_trigger
    before insert on conformity
    for each row execute procedure create_partition_and_insert();
	
/*Заполнение Source.id*/	
	
CREATE SEQUENCE seq_source_id start 1; 

create or replace function create_source() RETURNS trigger as $$
begin
	if new.id is null then
		new.id = 'TU' || ltrim(to_char(nextval('seq_source_id'),'99999'));
		RAISE NOTICE 'A partition has been created %',new.id;
	end if;
	return new;
end;
$$ LANGUAGE plpgsql;
create trigger source_insert_trigger
    before insert on source
    for each row execute procedure create_source();