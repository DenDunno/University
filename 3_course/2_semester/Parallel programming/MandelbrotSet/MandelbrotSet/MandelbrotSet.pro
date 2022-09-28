QT -= gui

CONFIG += c++17 console
CONFIG -= app_bundle
QMAKE_LFLAGS += -fopenmp
QMAKE_CXXFLAGS += -fopenmp
INCLUDEPATH += "C:\Program Files (x86)\Microsoft SDKs\MPI\Include"

# You can make your code fail to compile if it uses deprecated APIs.
# In order to do so, uncomment the following line.
#DEFINES += QT_DISABLE_DEPRECATED_BEFORE=0x060000    # disables all the APIs deprecated before Qt 6.0.0

SOURCES += \
        algorithms.cpp \
        bitmap.cpp \
        cpualgorithm.cpp \
        main.cpp \
        mandelbrotsetframealgorithm.cpp \
        openmpalgorithm.cpp

# Default rules for deployment.
qnx: target.path = /tmp/$${TARGET}/bin
else: unix:!android: target.path = /opt/$${TARGET}/bin
!isEmpty(target.path): INSTALLS += target


win32:CONFIG(release, debug|release): LIBS += -L'C:/Program Files (x86)/Microsoft SDKs/MPI/Lib/x64/' -lmsmpi
else:win32:CONFIG(debug, debug|release): LIBS += -L'C:/Program Files (x86)/Microsoft SDKs/MPI/Lib/x64/' -lmsmpi
else:unix: LIBS += -L'C:/Program Files (x86)/Microsoft SDKs/MPI/Lib/x64/' -lmsmpi

INCLUDEPATH += 'C:/Program Files (x86)/Microsoft SDKs/MPI/Lib/x64'
DEPENDPATH += 'C:/Program Files (x86)/Microsoft SDKs/MPI/Lib/x64'

win32:CONFIG(release, debug|release): LIBS += -L'C:/Program Files (x86)/Microsoft SDKs/MPI/Lib/x86/' -lmsmpi
else:win32:CONFIG(debug, debug|release): LIBS += -L'C:/Program Files (x86)/Microsoft SDKs/MPI/Lib/x86/' -lmsmpi
else:unix: LIBS += -L'C:/Program Files (x86)/Microsoft SDKs/MPI/Lib/x86/' -lmsmpi

INCLUDEPATH += 'C:/Program Files (x86)/Microsoft SDKs/MPI/Lib/x86'
DEPENDPATH += 'C:/Program Files (x86)/Microsoft SDKs/MPI/Lib/x86'

HEADERS += \
    algorithms.h \
    mandelbrotSetFramePiece.h \
    point.h \
    bitmap.h \
    cpualgorithm.h \
    mandelbrotsetframealgorithm.h \
    mandelbrotsetframedata.h \
    openmpalgorithm.h
