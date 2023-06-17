if [ -n "$ANDROID_NDK" ]; then
    export NDK=${ANDROID_NDK}
elif [ -n "$ANDROID_NDK_HOME" ]; then
    export NDK=${ANDROID_NDK_HOME}
elif [ -n "$ANDROID_NDK_HOME" ]; then
    export NDK=${ANDROID_NDK_HOME}
else
    export NDK=~/android-ndk-r25c
fi

if [ ! -d "$NDK" ]; then
    echo "Please set ANDROID_NDK environment to the root of NDK."
    exit 1
fi

function build() {
    API=$1
    ABI=$2
    BUILD_PATH=Android.${ABI}
    cmake -H. -B${BUILD_PATH} -DANDROID_ABI=${ABI} -DCMAKE_BUILD_TYPE=Release -DCMAKE_TOOLCHAIN_FILE=${NDK}/build/cmake/android.toolchain.cmake -DANDROID_NATIVE_API_LEVEL=${API}
    cmake --build ${BUILD_PATH} --config Release

    mkdir -p Plugins/Android/${ABI}/
    cp ${BUILD_PATH}/libphysfs.so Plugins/Android/${ABI}/libphysfs.so
}

build android-19 armeabi-v7a
build android-19 arm64-v8a