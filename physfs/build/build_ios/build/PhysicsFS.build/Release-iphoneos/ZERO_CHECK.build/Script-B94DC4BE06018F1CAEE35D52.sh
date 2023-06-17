#!/bin/sh
set -e
if test "$CONFIGURATION" = "Debug"; then :
  cd /Users/chenxiang/Documents/GitHub/Physfs-Unity/physfs/build/build_ios
  make -f /Users/chenxiang/Documents/GitHub/Physfs-Unity/physfs/build/build_ios/CMakeScripts/ReRunCMake.make
fi
if test "$CONFIGURATION" = "Release"; then :
  cd /Users/chenxiang/Documents/GitHub/Physfs-Unity/physfs/build/build_ios
  make -f /Users/chenxiang/Documents/GitHub/Physfs-Unity/physfs/build/build_ios/CMakeScripts/ReRunCMake.make
fi
if test "$CONFIGURATION" = "MinSizeRel"; then :
  cd /Users/chenxiang/Documents/GitHub/Physfs-Unity/physfs/build/build_ios
  make -f /Users/chenxiang/Documents/GitHub/Physfs-Unity/physfs/build/build_ios/CMakeScripts/ReRunCMake.make
fi
if test "$CONFIGURATION" = "RelWithDebInfo"; then :
  cd /Users/chenxiang/Documents/GitHub/Physfs-Unity/physfs/build/build_ios
  make -f /Users/chenxiang/Documents/GitHub/Physfs-Unity/physfs/build/build_ios/CMakeScripts/ReRunCMake.make
fi

