#pragma once

#include <iostream>
#include <vector>
#include <ctime>
#include <cstdint>
#include <string>

typedef  unsigned char Byte;
typedef std::vector<Byte> Buffer;
class IRequestHandler;
struct RequestResult;
struct RequestInfo;

enum CodeR : Byte {
    LoginCmd = 100,
    SignupCmd = 101,
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

struct RequestInfo {
    Byte id;
    std::time_t receivalTime;
    Buffer buff;
};

struct RequestResult {
    Buffer response;
    IRequestHandler* newHandler;
};

class IRequestHandler {
public:
    virtual ~IRequestHandler() = default; 

    virtual bool isRequestRelevant(const RequestInfo& reqInfo) = 0;
    virtual RequestResult handleRequest(const RequestInfo& reqInfo) = 0;
};