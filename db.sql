PGDMP                         z            Hospital    14.1    14.1 "               0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false                       0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false                       0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false                       1262    17385    Hospital    DATABASE     n   CREATE DATABASE "Hospital" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE = 'English_United States.1252';
    DROP DATABASE "Hospital";
                postgres    false            ?            1259    17422    __EFMigrationsHistory    TABLE     ?   CREATE TABLE public."__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL
);
 +   DROP TABLE public."__EFMigrationsHistory";
       public         heap    postgres    false            ?            1259    17477    book_appointment    TABLE       CREATE TABLE public.book_appointment (
    id integer NOT NULL,
    appintment_id smallint NOT NULL,
    service character varying(100),
    appointment_date date,
    appointment_mesaage character varying(100),
    appoinment_time time without time zone
);
 $   DROP TABLE public.book_appointment;
       public         heap    postgres    false            ?            1259    17476    book_appointment_id_seq    SEQUENCE     ?   CREATE SEQUENCE public.book_appointment_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 .   DROP SEQUENCE public.book_appointment_id_seq;
       public          postgres    false    214                       0    0    book_appointment_id_seq    SEQUENCE OWNED BY     S   ALTER SEQUENCE public.book_appointment_id_seq OWNED BY public.book_appointment.id;
          public          postgres    false    213            ?            1259    17512    contact    TABLE     ?   CREATE TABLE public.contact (
    firstname character varying(20),
    lastname character varying(20),
    email text NOT NULL,
    usermeassgae character varying(100)
);
    DROP TABLE public.contact;
       public         heap    postgres    false            ?            1259    17406    doctor_login    TABLE     l   CREATE TABLE public.doctor_login (
    email character varying(100),
    password character varying(100)
);
     DROP TABLE public.doctor_login;
       public         heap    postgres    false            ?            1259    17435    patient_register    TABLE       CREATE TABLE public.patient_register (
    id smallint NOT NULL,
    firstname character varying(100),
    lastname character varying(100),
    phonenumber numeric,
    address character varying(100),
    email character varying(100),
    password character varying(100)
);
 $   DROP TABLE public.patient_register;
       public         heap    postgres    false            ?            1259    17434    patient_register_id_seq    SEQUENCE     ?   CREATE SEQUENCE public.patient_register_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 .   DROP SEQUENCE public.patient_register_id_seq;
       public          postgres    false    212                       0    0    patient_register_id_seq    SEQUENCE OWNED BY     S   ALTER SEQUENCE public.patient_register_id_seq OWNED BY public.patient_register.id;
          public          postgres    false    211            ?            1259    17554    report_generation    TABLE     ?   CREATE TABLE public.report_generation (
    id integer NOT NULL,
    report_id integer,
    service character varying,
    appointment_date date,
    patient_details text,
    treatment_details text,
    recommendation text
);
 %   DROP TABLE public.report_generation;
       public         heap    postgres    false            ?            1259    17553    report_generation_id_seq    SEQUENCE     ?   CREATE SEQUENCE public.report_generation_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 /   DROP SEQUENCE public.report_generation_id_seq;
       public          postgres    false    217                       0    0    report_generation_id_seq    SEQUENCE OWNED BY     U   ALTER SEQUENCE public.report_generation_id_seq OWNED BY public.report_generation.id;
          public          postgres    false    216            s           2604    17480    book_appointment id    DEFAULT     z   ALTER TABLE ONLY public.book_appointment ALTER COLUMN id SET DEFAULT nextval('public.book_appointment_id_seq'::regclass);
 B   ALTER TABLE public.book_appointment ALTER COLUMN id DROP DEFAULT;
       public          postgres    false    214    213    214            r           2604    17529    patient_register id    DEFAULT     z   ALTER TABLE ONLY public.patient_register ALTER COLUMN id SET DEFAULT nextval('public.patient_register_id_seq'::regclass);
 B   ALTER TABLE public.patient_register ALTER COLUMN id DROP DEFAULT;
       public          postgres    false    211    212    212            t           2604    17557    report_generation id    DEFAULT     |   ALTER TABLE ONLY public.report_generation ALTER COLUMN id SET DEFAULT nextval('public.report_generation_id_seq'::regclass);
 C   ALTER TABLE public.report_generation ALTER COLUMN id DROP DEFAULT;
       public          postgres    false    217    216    217                      0    17422    __EFMigrationsHistory 
   TABLE DATA           R   COPY public."__EFMigrationsHistory" ("MigrationId", "ProductVersion") FROM stdin;
    public          postgres    false    210   ?'                 0    17477    book_appointment 
   TABLE DATA           ~   COPY public.book_appointment (id, appintment_id, service, appointment_date, appointment_mesaage, appoinment_time) FROM stdin;
    public          postgres    false    214   1(                 0    17512    contact 
   TABLE DATA           K   COPY public.contact (firstname, lastname, email, usermeassgae) FROM stdin;
    public          postgres    false    215   {(                 0    17406    doctor_login 
   TABLE DATA           7   COPY public.doctor_login (email, password) FROM stdin;
    public          postgres    false    209   ?(                 0    17435    patient_register 
   TABLE DATA           j   COPY public.patient_register (id, firstname, lastname, phonenumber, address, email, password) FROM stdin;
    public          postgres    false    212   ?(                 0    17554    report_generation 
   TABLE DATA           ?   COPY public.report_generation (id, report_id, service, appointment_date, patient_details, treatment_details, recommendation) FROM stdin;
    public          postgres    false    217   ?)                  0    0    book_appointment_id_seq    SEQUENCE SET     G   SELECT pg_catalog.setval('public.book_appointment_id_seq', 113, true);
          public          postgres    false    213                       0    0    patient_register_id_seq    SEQUENCE SET     F   SELECT pg_catalog.setval('public.patient_register_id_seq', 46, true);
          public          postgres    false    211                       0    0    report_generation_id_seq    SEQUENCE SET     G   SELECT pg_catalog.setval('public.report_generation_id_seq', 45, true);
          public          postgres    false    216            v           2606    17426 .   __EFMigrationsHistory PK___EFMigrationsHistory 
   CONSTRAINT     {   ALTER TABLE ONLY public."__EFMigrationsHistory"
    ADD CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId");
 \   ALTER TABLE ONLY public."__EFMigrationsHistory" DROP CONSTRAINT "PK___EFMigrationsHistory";
       public            postgres    false    210            z           2606    17482 &   book_appointment book_appointment_pkey 
   CONSTRAINT     d   ALTER TABLE ONLY public.book_appointment
    ADD CONSTRAINT book_appointment_pkey PRIMARY KEY (id);
 P   ALTER TABLE ONLY public.book_appointment DROP CONSTRAINT book_appointment_pkey;
       public            postgres    false    214            |           2606    17518    contact contact_email_key 
   CONSTRAINT     U   ALTER TABLE ONLY public.contact
    ADD CONSTRAINT contact_email_key UNIQUE (email);
 C   ALTER TABLE ONLY public.contact DROP CONSTRAINT contact_email_key;
       public            postgres    false    215            x           2606    17531 &   patient_register patient_register_pkey 
   CONSTRAINT     d   ALTER TABLE ONLY public.patient_register
    ADD CONSTRAINT patient_register_pkey PRIMARY KEY (id);
 P   ALTER TABLE ONLY public.patient_register DROP CONSTRAINT patient_register_pkey;
       public            postgres    false    212            ~           2606    17561 (   report_generation report_generation_pkey 
   CONSTRAINT     f   ALTER TABLE ONLY public.report_generation
    ADD CONSTRAINT report_generation_pkey PRIMARY KEY (id);
 R   ALTER TABLE ONLY public.report_generation DROP CONSTRAINT report_generation_pkey;
       public            postgres    false    217                       2606    17532    book_appointment fk_patient    FK CONSTRAINT     ?   ALTER TABLE ONLY public.book_appointment
    ADD CONSTRAINT fk_patient FOREIGN KEY (appintment_id) REFERENCES public.patient_register(id);
 E   ALTER TABLE ONLY public.book_appointment DROP CONSTRAINT fk_patient;
       public          postgres    false    212    3192    214               M   x?320220143?4?02?H,?L?+	JM?,.I-?4?3?34?2???447654????,I?	K-*??σ?????? XB?         :   x?34??41?tI?+I?Q(N-*?LN?4202?50?5???+K??40?20 "?=... j?            x?????? ? ?         #   x?+.O,?tH?M???K????NLI??????? ???         ?   x?]???0D?ӏ!R+?M?&^?rY ?
?? ~??S?4?μ?S1????$n=?H#K?c?Ke???.?1.?鮉ۨ?????^?=?c=q??;???]?? _?W???k~og??$?????:َد?W֡???`???L]C??]t?D?7dl?+??z?<B| ?]e            x?e?A1E?p
/P?P?z7?P?d?$Ř???8qc?<6<`&??о.????R?D\D???"??=?]???x?j?)????2??ʟ??????C??|?Y??~k?`???:??#"~ Ok3?     