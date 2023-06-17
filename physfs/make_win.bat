mkdir build64 & pushd build64
cmake -G "Visual Studio 17 2022" -A Win32 ..
popd
cmake --build build64 --config Release
