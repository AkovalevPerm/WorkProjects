ALTER TABLE public.Uslovie add COLUMN createtime timestamp(3) without time zone;
ALTER TABLE public.Uslovie add COLUMN creator character varying(255);
ALTER TABLE public.Uslovie add COLUMN edittime timestamp(3) without time zone;
ALTER TABLE public.Uslovie add COLUMN editor character varying(255);