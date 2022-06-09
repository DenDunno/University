#ifndef LAB_3_HOOK_H
#define LAB_3_HOOK_H
#include <Windows.h>
#include <iostream>

HHOOK hHook{ NULL };

enum Keys
{
    ShiftKey = 16,
    Capital = 20,
};

int shift_active()
{
    return GetKeyState(VK_LSHIFT) < 0 || GetKeyState(VK_RSHIFT) < 0;
}

int capital_active()
{
    return (GetKeyState(VK_CAPITAL) & 1) == 1;
}

LRESULT CALLBACK keyboard_hook(const int code, const WPARAM wParam, const LPARAM lParam)
{
    if (wParam == WM_KEYDOWN)
    {
        KBDLLHOOKSTRUCT *kbdStruct = (KBDLLHOOKSTRUCT*)lParam;
        DWORD wVirtKey = kbdStruct->vkCode;
        DWORD wScanCode = kbdStruct->scanCode;

        BYTE lpKeyState[256];
        GetKeyboardState(lpKeyState);
        lpKeyState[Keys::ShiftKey] = 0;
        lpKeyState[Keys::Capital] = 0;

        if (shift_active())
        {
            lpKeyState[Keys::ShiftKey] = 0x80;
        }
        if (capital_active())
        {
            lpKeyState[Keys::Capital] = 0x01;
        }

        char result;
        ToAscii(wVirtKey, wScanCode, lpKeyState, (LPWORD)&result, 0);
        std::cout << result << std::endl;
    }

    return CallNextHookEx(hHook, code, wParam, lParam);
}

int hook()
{
    hHook = SetWindowsHookEx(WH_KEYBOARD_LL, keyboard_hook, NULL, 0);

    if (hHook == NULL)
    {
        std::cout << "Keyboard hook failed!" << std::endl;
    }

    while (GetMessage(NULL, NULL, 0, 0));

    return 0;
}

#endif
