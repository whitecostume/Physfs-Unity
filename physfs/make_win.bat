mkdir build_win & pushd build_win
cmake -G "Visual Studio 17 2022" ..
popd
cmake --build build_win --config Release

md Plugins\X64\
copy /Y build_win\Release\physfs.dll Plugins\X64\physfs.dll