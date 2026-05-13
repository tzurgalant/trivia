#pragma once

#include <iostream>
#include <vector>
#include <ctime>
#include <cstdint>
#include <string>
#include <WinSock2.h>
#include "Room.h"
typedef  unsigned char Byte;
typedef std::vector<Byte> Buffer;
class IRequestHandler;
struct RequestResult;
struct RequestInfo;

enum CodeR : Byte {
    LoginCmd = 100,
    SignupCmd,
    ErrorCmd,
    LogoutCmd,
    GetRoomsCmd,
    GetPlayersInRoomCmd,
    JoinRoomCmd,
    CreateRoomCmd,
    GetHighScoreResponseCmd,
    GetPersonalStatsCmd
};

//for the serialzer
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

struct LogoutResponse
{
    unsigned int status;
};

//rooms serializer
struct GetRoomsResponse
{
    unsigned int status;
    std::vector<RoomData> rooms;
};

struct GetPlayersInRoomResponse
{
    std::vector<std::string> players;
};

struct JoinRoomResponse
{
    unsigned int status;
};

struct CreateRoomResponse
{
    unsigned int status;
};
struct GetHighScoreResponse
{
    unsigned int status;
    std::vector<std::string>statistics;
};

struct GetPersonalStatsReponse
{
    unsigned int status;
    std::vector<std::string>statistics;
};

//for deserializer
struct LoginRequest {
    std::string userName;
    std::string password;
};

struct SignupRequest {
    std::string userName;
    std::string password;
    std::string email;
};

/* here */

//rooms deserializer related
struct GetPlayersinRoomRequest {
    unsigned int roomld;
};

struct JoinRoomRequest {
    unsigned int roomld;
};

struct CreateRoomRequest {
    std::string roomName;
    unsigned int maxUsers;
    unsigned int questionCount;
    unsigned int answerTimeout;
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
    IRequestHandler* newHandler = nullptr;
};

// interfuce 
class IRequestHandler {
public:
    virtual ~IRequestHandler() = default; 

    virtual bool isRequestRelevant(const RequestInfo& reqInfo) = 0;
    virtual RequestResult handleRequest(const RequestInfo& reqInfo) = 0;
};