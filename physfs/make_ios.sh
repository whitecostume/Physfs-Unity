mkdir -p build_ios && cd build_ios
cmake -DCMAKE_TOOLCHAIN_FILE=../cmake/ios.toolchain.cmake -DPLATFORM=OS64 -DPHYSFS_DISABLE_INSTALL=OFF -GXcode ../
cd ..
cmake --build build_ios --config Release