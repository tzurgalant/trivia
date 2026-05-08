#pragma once

#include <iostream>
#include <vector>
#include <ctime>
#include <cstdint>
#include <string>
#include <WinSock2.h>

typedef  unsigned char Byte;
typedef std::vector<Byte> Buffer;
class IRequestHandler;
struct RequestResult;
struct RequestInfo;

enum CodeR : Byte {
    LoginCmd = 100,
    SignupCmd = 101,
};

//for 
struct LoginResponse
{
    unsigned int status;
};
struct ErrorResponse
{
    std::string message;
};
struct SignupResponse
{
    unsigned int status;
};

struct LoginRequest {
    std::string userName;
    std::string password;
};

struct SignupRequest {
    std::string userName;
    std::string password;
    std::string email;
};
//
struct RequestInfo {
    Byte id;
    std::time_t receivalTime;
    Buffer buff;
    SOCKET userSocket;
};

struct RequestResult {
    Buffer response;
    IRequestHandler* newHandler;
};
// interfuce 
class IRequestHandler {
public:
    virtual ~IRequestHandler() = default; 

    virtual bool isRequestRelevant(const RequestInfo& reqInfo) = 0;
    virtual RequestResult handleRequest(const RequestInfo& reqInfo) = 0;
};