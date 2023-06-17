mkdir build_win & pushd build_win
cmake -G "Visual Studio 17 2022" -A Win32 ..
popd
cmake --build build_win --config Release
