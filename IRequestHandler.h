#pragma once

#include <iostream>
#include <vector>
#include <map>
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
    GetPersonalStatsCmd,
    JoinRoomCmd,
    CreateRoomCmd,
    GetHighScoreCmd,
    CloseRoomCmd,
    StartGameCmd,
    GetRoomStateCmd,
	LeaveRoomCmd,
    GetGameResultsResponseCmd,
    SubmitAnswerResponseCmd,
    GetQuestionResponseCmd,
    LeaveGameResponseCmd
};

//login/signup serialzer
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
    unsigned int roomId;/// more easy for the client side
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

//login/signup deserializer
struct LoginRequest {
    std::string userName;
    std::string password;
};

struct SignupRequest {
    std::string userName;
    std::string password;
    std::string email;
};

//rooms deserializer
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

//rooms seraliazer
struct CloseRoomResponse {
    unsigned int status;
};

struct StartGameResponse {
    unsigned int status;
};

struct LeaveRoomResponse {
    unsigned int status;
};

struct GetRoomStateResponse {
    unsigned int status;
    bool hasGameBegun;
    std::vector<std::string> players;
    unsigned int questionCount;
    unsigned int answerTimeOut;
};

//game deseraliazer
struct SubmitAnswerRequest
{
    unsigned int answerId;
};

//game seraliazer
struct LeaveGameResponse
{
    unsigned int status;
};

struct GetQuestionResponse
{
    unsigned int status;
    std::string question;
    std::map<unsigned int, std::string> answers;
};

struct SubmitAnswerResponse
{
    unsigned int status;
    unsigned int correctAnswerId;
};

struct PlayerResult
{
    std::string userName;
    unsigned int correctAnswersCount;
    unsigned int wrongAnswersCount;
    unsigned int averageAnswersTime;
};

struct GetGameResultsResponse
{
    unsigned int status;
    std::vector<PlayerResult> results;
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