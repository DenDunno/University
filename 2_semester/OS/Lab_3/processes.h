#ifndef LAB_3_PROCESSES_H
#define LAB_3_PROCESSES_H
#include <iostream>
#include<windows.h>
#include <tchar.h>
#include <psapi.h>
#include <processthreadsapi.h>
#include <string>
#include <codecvt>
#include<Shlwapi.h>
#include <locale>
#pragma warning( disable : 4996 )
#pragma warning( disable : 4700 )
#pragma comment(lib,"Shlwapi")

int processes()
{
    DWORD procID;
    char text[] = "Process Running Now";
    wchar_t wtext[20];
    mbstowcs(wtext, text, strlen(text) + 1);
    LPWSTR ptr = wtext;
    HANDLE hProc = NULL;

    HWND Window = NULL;
    Window = FindWindow(NULL, reinterpret_cast<LPCSTR>(ptr));

    if (!Window)
    {
        std::cout << "Window not found" << '\n';
        return 1;
    }
    else
    {
        if (!GetWindowThreadProcessId(Window, &procID))
        {
            std::cerr << "Get window process ID error: " << GetLastError() << '\n';
            return 1;
        }
    }

    if (procID != 0)
        hProc = OpenProcess(PROCESS_ALL_ACCESS, FALSE, procID);

    if (!hProc)
    {
        std::cerr << "Can not open process: " << GetLastError() << '\n';
        return 2;
    }
    else
    {
        std::cout << "Process Found and Ready to Read" << '\n';
    }

    CHAR buffer[sizeof(int)];
    std::cout << "Enter address: \n";
    wchar_t* argv = (wchar_t*)malloc(100);
    std::wcin >> argv;

    LONGLONG addr;
    SIZE_T bytesRead;
    StrToInt64Ex(reinterpret_cast<LPCSTR>(argv), STIF_SUPPORT_HEX, &addr);
    memset(buffer, 0x0, sizeof(int));;

    while (ReadProcessMemory(hProc, (LPCVOID)addr, (LPVOID)buffer, sizeof(int), &bytesRead))
    {
        Sleep(1000);
        int* valP = reinterpret_cast<int*>(&buffer);
        int val = *valP;
        _tprintf(_T("Successfully read: %d\n"), val);
    }

    CloseHandle(Window);
    CloseHandle(hProc);

    return 0;
}

#endif
