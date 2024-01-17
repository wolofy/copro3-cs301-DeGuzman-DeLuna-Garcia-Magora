USE [C:\USERS\WOLF\SOURCE\REPOS\NINJASAGATP\NINJAPROFILES.MDF]
GO

/****** Object: Table [dbo].[ninja_profiles] Script Date: 1/17/2024 5:19:49 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ninja_profiles] (
    [Id]                   INT          IDENTITY (1, 1) NOT NULL,
    [name]                 VARCHAR (50) NOT NULL,
    [gender]               VARCHAR (20) NOT NULL,
    [body_type]            VARCHAR (20) NOT NULL,
    [skin_tone]            VARCHAR (20) NOT NULL,
    [hair_style]           VARCHAR (20) NOT NULL,
    [hair_color]           VARCHAR (20) NOT NULL,
    [face_shape]           VARCHAR (20) NOT NULL,
    [eyebrows]             VARCHAR (20) NOT NULL,
    [eye_shape]            VARCHAR (20) NOT NULL,
    [eye_color]            VARCHAR (20) NOT NULL,
    [facial_hair]          VARCHAR (20) NOT NULL,
    [top_attire]           VARCHAR (20) NOT NULL,
    [top_attire_color]     VARCHAR (20) NOT NULL,
    [bottom_attire]        VARCHAR (20) NOT NULL,
    [bottom_attire_color]  VARCHAR (20) NOT NULL,
    [footwear]             VARCHAR (20) NOT NULL,
    [footwear_color]       VARCHAR (20) NOT NULL,
    [headdress]            VARCHAR (20) NOT NULL,
    [facewear]             VARCHAR (20) NOT NULL,
    [bloodline]            VARCHAR (20) NOT NULL,
    [element]              VARCHAR (20) NOT NULL,
    [village]              VARCHAR (20) NOT NULL,
    [weapon]               VARCHAR (20) NOT NULL,
    [hit_particle_color]   VARCHAR (20) NOT NULL,
    [character_aura_color] VARCHAR (20) NOT NULL,
    [strength]             INT          NOT NULL,
    [intelligence]         INT          NOT NULL,
    [agility]              INT          NOT NULL,
    [vitality]             INT          NOT NULL,
    [is_villain]           VARCHAR (20) NOT NULL
);


