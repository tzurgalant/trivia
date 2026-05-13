#include "JsonResponsePacketSerializer.h"
#include "json.hpp"
#include <vector>
#include <string>

using json = nlohmann::json;

Buffer JsonResponsePacketSerializer::serializeResponse(LoginResponse res)
{
    json j;
    j["status"] = res.status;

    std::string jsonStr = j.dump();

    Buffer buffer;

    //msg code
    buffer.push_back(LoginCmd);

    unsigned int length = jsonStr.length();

    buffer.push_back((length >> 24) & 0xFF);
    buffer.push_back((length >> 16) & 0xFF);
    buffer.push_back((length >> 8) & 0xFF);
    buffer.push_back(length & 0xFF);

    for (char c : jsonStr)
    {
        buffer.push_back((unsigned char)c);
    }

    return buffer;
}

Buffer JsonResponsePacketSerializer::serializeResponse(SignupResponse res)
{
    json j;
    j["status"] = res.status;

    std::string jsonStr = j.dump();

    Buffer buffer;

    //msg code
    buffer.push_back(SignupCmd);

    unsigned int length = jsonStr.length();

    buffer.push_back((length >> 24) & 0xFF);
    buffer.push_back((length >> 16) & 0xFF);
    buffer.push_back((length >> 8) & 0xFF);
    buffer.push_back(length & 0xFF);

    for (char c : jsonStr)
    {
        buffer.push_back((unsigned char)c);
    }

    return buffer;
}
Buffer JsonResponsePacketSerializer::serializeResponse(ErrorResponse req)
{
    // make the jsons part
    json j;
    j["message"] = req.message; 

    std::string jsonStr = j.dump();
    Buffer buffer;

    buffer.push_back(ErrorCmd);

    unsigned int length = jsonStr.length();
    buffer.push_back((length >> 24) & 0xFF);
    buffer.push_back((length >> 16) & 0xFF);
    buffer.push_back((length >> 8) & 0xFF);
    buffer.push_back(length & 0xFF);

    for (char c : jsonStr)
    {
        buffer.push_back((unsigned char)c);
    }

    return buffer;
}
Buffer JsonResponsePacketSerializer::serializerReqponse(ErrorResponse req)
{

}
Buffer JsonResponsePacketSerializer::serializerReqponse(LogoutResponse req)
{

}
Buffer JsonResponsePacketSerializer::serializerReqponse(GetRoomsResponse req)
{

}
Buffer JsonResponsePacketSerializer::serializerReqponse(GetPlayersInRoomResponse req)
{

}
Buffer JsonResponsePacketSerializer::serializerReqponse(JoinRoomResponse req)
{

}
Buffer JsonResponsePacketSerializer::serializerReqponse(CreateRoomResponse req)
{

}
Buffer JsonResponsePacketSerializer::serializerReqponse(GetHighScoreResponse req)
{

}
Buffer JsonResponsePacketSerializer::serializerReqponse(GetPersonalStatsReponse req)
{

}