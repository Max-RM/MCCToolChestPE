cmake_minimum_required(VERSION 3.16)

if(NOT CMAKE_GENERATOR_PLATFORM STREQUAL "ARM")
  message(FATAL_ERROR "This project must be configured for ARM (32-bit). Use: cmake -A ARM ...")
endif()

project(LevelDB-MCPE LANGUAGES C CXX)

include(FetchContent)

set(FETCHCONTENT_QUIET OFF)
FetchContent_Declare(
  zlib
  GIT_REPOSITORY https://github.com/madler/zlib.git
  GIT_TAG v1.3.1
)
FetchContent_GetProperties(zlib)
if(NOT zlib_POPULATED)
  FetchContent_Populate(zlib)
  set(_saved_build_shared "${BUILD_SHARED_LIBS}")
  set(BUILD_SHARED_LIBS OFF)
  add_subdirectory("${zlib_SOURCE_DIR}" "${zlib_BINARY_DIR}" EXCLUDE_FROM_ALL)
  set(BUILD_SHARED_LIBS "${_saved_build_shared}")
endif()

if(TARGET zlibstatic AND NOT TARGET zlib)
  add_library(zlib ALIAS zlibstatic)
endif()

set(BUILD_SHARED_LIBS ON CACHE BOOL "" FORCE)
set(LEVELDB_BUILD_TESTS OFF CACHE BOOL "" FORCE)
set(LEVELDB_BUILD_BENCHMARKS OFF CACHE BOOL "" FORCE)
set(LEVELDB_INSTALL OFF CACHE BOOL "" FORCE)
set(LEVELDB_SUPPORT_LEGACY_ZLIB_ENUM ON CACHE BOOL "" FORCE)
set(HAVE_ZLIB 1 CACHE BOOL "" FORCE)

add_subdirectory("${CMAKE_CURRENT_LIST_DIR}/.." "${CMAKE_BINARY_DIR}/leveldb")

set_target_properties(leveldb PROPERTIES
  OUTPUT_NAME "LevelDB-MCPE-ARM32"
  PREFIX ""
)

install(TARGETS leveldb RUNTIME DESTINATION .)
