FROM microsoft/windowsservercore:1709

WORKDIR /parcs-hostserver

EXPOSE 1234

EXPOSE 1236

COPY . .

CMD ["HostServer.exe", "--docker"]