cmake_minimum_required(VERSION 3.25)
project(p2)

set(CMAKE_CXX_STANDARD 14)

include_directories(.)

add_executable(p2
        lumen.cpp
        lumen.h
        nova.cpp
        nova.h
        P2.cpp)
