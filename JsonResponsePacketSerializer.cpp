
#include "JsonResponsePacketSerializer.h"
#include "json.hpp"
#include <vector>
#include <string>
using json = nlohmann::json;
static void to_json(json& j, const RoomData& r) {// because we have a vector of rooms data we need furnion that said the class how to create the json...
    j = json{
        {"id", r.id},
        {"name", r.name},
        {"maxPlayers", r.maxPlayers},
        {"numOfQuestionsInGame", r.numOfQuestionsInGame},
        {"timePerQuestion", r.timePerQuestion},
        {"room status",r.status}
    };
}

Buffer createBuffer(CodeR codeR, unsigned int length, std::string data)
{
    Buffer buffer;
    // make the buffer headdres
    buffer.push_back(codeR);

    buffer.push_back((length >> 24) & 0xFF);
    buffer.push_back((length >> 16) & 0xFF);
    buffer.push_back((length >> 8) & 0xFF);
    buffer.push_back(length & 0xFF);
    // add to the buffer the data 
    for (char c : data)
    {
        buffer.push_back((unsigned char)c);
    }

    return buffer;
}

Buffer JsonResponsePacketSerializer::serializeResponse(LoginResponse res)
{
    //create data
    json j;
    j["status"] = res.status;

    std::string jsonStr = j.dump();

    //create buffer whit the data and this request commens
    return createBuffer(LoginCmd, jsonStr.length(), jsonStr);
}

Buffer JsonResponsePacketSerializer::serializeResponse(SignupResponse res)
{
    //create data
    json j;
    j["status"] = res.status;

    std::string jsonStr = j.dump();

    //create buffer whit the data and this request commens
    return createBuffer(SignupCmd, jsonStr.length(), jsonStr);
}
Buffer JsonResponsePacketSerializer::serializeResponse(ErrorResponse res)
{
    // make the jsons part
    json j;
    j["message"] = res.message;

    std::string jsonStr = j.dump();

    //create buffer whit the data and this request commens
    return createBuffer(ErrorCmd, jsonStr.length(), jsonStr);

}
Buffer JsonResponsePacketSerializer::serializeResponse(LogoutResponse res)
{
    // make the jsons part
    json j;
    j["status"] = res.status;

    std::string jsonStr = j.dump();

    //create buffer whit the data and this request commens
    return createBuffer(ErrorCmd, jsonStr.length(), jsonStr);
}
Buffer JsonResponsePacketSerializer::serializeResponse(GetRoomsResponse res)
{
    // make the jsons part
    json j;
    j["status"] = res.status;
    j["rooms"] = res.rooms;
    std::string jsonStr = j.dump();

    //create buffer whit the data and this request commens
    return createBuffer(ErrorCmd, jsonStr.length(), jsonStr);
}
Buffer JsonResponsePacketSerializer::serializeResponse(GetPlayersInRoomResponse res)
{
    // make the jsons part
    json j;
    j["players"] = res.players;

    std::string jsonStr = j.dump();

    //create buffer whit the data and this request commens
    return createBuffer(ErrorCmd, jsonStr.length(), jsonStr);
}
Buffer JsonResponsePacketSerializer::serializeResponse(JoinRoomResponse res)
{
    // make the jsons part
    json j;
    j["status"] = res.status;

    std::string jsonStr = j.dump();

    //create buffer whit the data and this request commens
    return createBuffer(ErrorCmd, jsonStr.length(), jsonStr);
}
Buffer JsonResponsePacketSerializer::serializeResponse(CreateRoomResponse res)
{
    // make the jsons part
    json j;
    j["status"] = res.status;

    std::string jsonStr = j.dump();

    //create buffer whit the data and this request commens
    return createBuffer(ErrorCmd, jsonStr.length(), jsonStr);
}
Buffer JsonResponsePacketSerializer::serializeResponse(GetHighScoreResponse res)
{
    // make the jsons part
    json j;
    j["status"] = res.status;
    j["statistics"] = res.statistics;

    std::string jsonStr = j.dump();

    //create buffer whit the data and this request commens
    return createBuffer(ErrorCmd, jsonStr.length(), jsonStr);
}
Buffer JsonResponsePacketSerializer::serializeResponse(GetPersonalStatsReponse res)
{
    // make the jsons part
    json j;
    j["status"] = res.status;
    j["statistics"] = res.statistics;

    std::string jsonStr = j.dump();

    //create buffer whit the data and this request commens
    return createBuffer(ErrorCmd, jsonStr.length(), jsonStr);
}