mkdir -p build_osx && cd build_osx
cmake -GXcode ../
cd ..
cmake --build build_osx --config Release

mkdir -p Plugins/OSX/
cp build_osx/Release/libphysfs.*.dylib Plugins/OSX/libphysfs.dylib 