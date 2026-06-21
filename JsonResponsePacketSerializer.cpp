
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
static void to_json(json& j, const PlayerResult& r)// for the vector of playerResult
{
    j = json{
        {"userName",r.userName},
        {"correctAnswersCount",r.correctAnswersCount},
        {"wrongAnswersCount",r.wrongAnswersCount},
        {"averageAnswersTime",r.averageAnswersTime}
    };
}
static void to_json(json& j, const GetQuestionResponse& q)//for the map of answers in GetQuestion  REsponse take all the data in the start and convert to json 
{
    j = json{
        {"status", q.status},
        {"question", q.question},
        {"answers", q.answers}
    };
}
Buffer createBuffer(CodeR codeR, unsigned int length, std::string data)
{
    Buffer buffer;
    // make the buffer headdres
    buffer.push_back(codeR);
    // four firsy byte is for the length 
    buffer.push_back((length >> 24) & 0xFF);
    buffer.push_back((length >> 16) & 0xFF);
    buffer.push_back((length >> 8) & 0xFF);
    buffer.push_back(length & 0xFF);
    // add to the buffer the data 
    for (char c : data)
    {
        buffer.push_back((unsigned char)c);
    }
    std::cout << "SERVER SENDING JSON: " << data << std::endl;
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
    return createBuffer(LogoutCmd, jsonStr.length(), jsonStr);
}
Buffer JsonResponsePacketSerializer::serializeResponse(GetRoomsResponse res)
{
    // make the jsons part
    json j;
    j["status"] = res.status;
    j["rooms"] = res.rooms;
    std::string jsonStr = j.dump();

    //create buffer whit the data and this request commens
    return createBuffer(GetRoomsCmd, jsonStr.length(), jsonStr);
}
Buffer JsonResponsePacketSerializer::serializeResponse(GetPlayersInRoomResponse res)
{
    // make the jsons part
    json j;
    j["players"] = res.players;

    std::string jsonStr = j.dump();

    //create buffer whit the data and this request commens
    return createBuffer(GetPlayersInRoomCmd, jsonStr.length(), jsonStr);
}
Buffer JsonResponsePacketSerializer::serializeResponse(JoinRoomResponse res)
{
    // make the jsons part
    json j;
    j["status"] = res.status;

    std::string jsonStr = j.dump();

    //create buffer whit the data and this request commens
    return createBuffer(JoinRoomCmd, jsonStr.length(), jsonStr);
}
Buffer JsonResponsePacketSerializer::serializeResponse(CreateRoomResponse res)
{
    // make the jsons part
    json j;
    j["status"] = res.status;
    j["roomId"] = res.roomId;

    std::string jsonStr = j.dump();

    //create buffer whit the data and this request commens
    return createBuffer(CreateRoomCmd, jsonStr.length(), jsonStr);
}
Buffer JsonResponsePacketSerializer::serializeResponse(GetHighScoreResponse res)
{
    // make the jsons part
    json j;
    j["status"] = res.status;
    j["statistics"] = res.statistics;

    std::string jsonStr = j.dump();

    //create buffer whit the data and this request commens
    return createBuffer(GetHighScoreCmd, jsonStr.length(), jsonStr);
}
Buffer JsonResponsePacketSerializer::serializeResponse(GetPersonalStatsReponse res)
{
    // make the jsons part
    json j;
    j["status"] = res.status;
    j["statistics"] = res.statistics;

    std::string jsonStr = j.dump();

    //create buffer whit the data and this request commens
    return createBuffer(GetPersonalStatsCmd, jsonStr.length(), jsonStr);
}

Buffer JsonResponsePacketSerializer::serializeResponse(CloseRoomResponse res)
{
    // make the jsons part
    json j;
    j["status"] = res.status;

    std::string jsonStr = j.dump();

    //create buffer whit the data and this request commens
    return createBuffer(CloseRoomCmd, jsonStr.length(), jsonStr);
}

Buffer JsonResponsePacketSerializer::serializeResponse(StartGameResponse res)
{
    // make the jsons part
    json j;
    j["status"] = res.status;

    std::string jsonStr = j.dump();

    //create buffer whit the data and this request commens
    return createBuffer(StartGameCmd, jsonStr.length(), jsonStr);
}

Buffer JsonResponsePacketSerializer::serializeResponse(LeaveRoomResponse res)
{
    // make the jsons part
    json j;
    j["status"] = res.status;

    std::string jsonStr = j.dump();

    //create buffer whit the data and this request commens
    return createBuffer(LeaveRoomCmd, jsonStr.length(), jsonStr);
}

Buffer JsonResponsePacketSerializer::serializeResponse(GetRoomStateResponse res)
{
    // make the jsons part
    json j;
    j["status"] = res.status;
    j["hasGameBegun"] = res.hasGameBegun;
    j["players"] = res.players;
    j["questionCount"] = res.questionCount;
    j["answerTimeOut"] = res.answerTimeOut;

    std::string jsonStr = j.dump();

    //create buffer whit the data and this request commens
    return createBuffer(GetRoomStateCmd, jsonStr.length(), jsonStr);
}
Buffer JsonResponsePacketSerializer::serializeResponse(const GetGameResultsResponse& response)
{
    json j;
    j["status"] = response.status;
    j["results"] = response.results;

    std::string jsonStr = j.dump();

    return createBuffer(GetGameResultsCmd,jsonStr.length(),jsonStr);
    
}
Buffer JsonResponsePacketSerializer::serializeResponse(const SubmitAnswerResponse& response)
{
    json j;
    j["status"] = response.status;
    j["correctAnswerId"] = response.correctAnswerId;

    std::string jsonStr = j.dump();

    return createBuffer(SubmitAnswerCmd, jsonStr.length(), jsonStr);
}
Buffer JsonResponsePacketSerializer::serializeResponse(const GetQuestionResponse& response)
{ 
    json j = response;// we make toJson for this obeject

    std::string jsonStr = j.dump();
    return createBuffer(GetQuestionCmd, jsonStr.length(), jsonStr);

}
Buffer JsonResponsePacketSerializer::serializeResponse(const LeaveGameResponse& response)
{
    json j;
    j["status"] = response.status;

    std::string jsonStr = j.dump();

    return createBuffer(SubmitAnswerCmd, jsonStr.length(), jsonStr);

}