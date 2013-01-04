# Environment Verifier

The **Environment Verifier** is a tool that helps users verify if a Windows 7 instance (local or remote) has certain pre-requisites (e.g.: files, databases, Windows Services etc) in place.

## Check for pre-requisites before deploying your app

Most applications require a machine to be 'prepped' before installation. This tool reads in a file and verifies system resources.

e.g: 
- A Windows service might be verifies against a Name (Dhcp) and a Status (Running)
- A File system can be verifies against a file name (C:\Windows\hh.exe)

