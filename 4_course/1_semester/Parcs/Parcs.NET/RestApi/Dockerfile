FROM microsoft/iis:windowsservercore-1709

SHELL ["powershell"]

RUN mkdir C:\site

WORKDIR C:/site

RUN Install-WindowsFeature NET-Framework-45-ASPNET ; \  
    Install-WindowsFeature Web-Asp-Net45

RUN Import-module IISAdministration; \
    New-IISSite -Name ParcsWebSite -PhysicalPath C:\site -BindingInformation "*:8000:"

EXPOSE 8000

RUN mkdir C:\ParcsModules

COPY index.html C:/site
COPY bin C:/site/bin
COPY obj C:/site/obj
COPY app/css C:/site/app/css
COPY app/bundle.js  C:/site/app
COPY app/views C:/site/app/views
COPY app/fonts C:/site/app/fonts
COPY app/resources C:/site/app/resources
COPY Web.config C:/site