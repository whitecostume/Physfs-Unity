mkdir -p build_ios && cd build_ios
cmake -DCMAKE_TOOLCHAIN_FILE=../cmake/ios.toolchain.cmake -DPLATFORM=OS64 -DPHYSFS_DISABLE_INSTALL=ON -GXcode ../
cd ..
cmake --build build_ios --config Release -- CODE_SIGNING_ALLOWED=NO

mkdir -p Plugins/iOS/
cp build_ios/Release/libphysfs.a Plugins/iOS/libphysfs.a 