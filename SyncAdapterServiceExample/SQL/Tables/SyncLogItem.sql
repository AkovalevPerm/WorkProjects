CREATE TABLE IF NOT EXISTS public.synclogitem
(
  primarykey uuid NOT NULL,
  created timestamp(3) without time zone,
  changesfrom timestamp(3) without time zone,
  changesto timestamp(3) without time zone,
  direction character varying(9),
  dataset text,
  datasource character varying(100),
  processed timestamp(3) without time zone,
  description text,
  resultinfo text,
  status character varying(29),
  createtime timestamp(3) without time zone,
  creator character varying(255),
  edittime timestamp(3) without time zone,
  editor character varying(255),
  CONSTRAINT synclogitem_pkey PRIMARY KEY (primarykey)
);