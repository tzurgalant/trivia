#include "JsonRequestPacketDeserializer.h"
#include "json.hpp"         



using json = nlohmann::json;

LoginRequest JsonRequestPacketDeserializer::deserializeLoginRequest(const Buffer& buffer) {
    try {
        // convert the buffer to strtuct that easy to work whit it 
        auto j = json::parse(buffer.begin(), buffer.end());

        LoginRequest req;
        req.userName = j["username"]; 
        req.password = j["password"];
        return req;
    }
    catch (const std::exception& e) {
        throw std::runtime_error("Error parsing login JSON: " + std::string(e.what()));
    }
}

SignupRequest JsonRequestPacketDeserializer::deserializeSignupRequest(const Buffer& buffer)
{
    try
    {
         json j = json::parse(buffer.begin(), buffer.end());

        SignupRequest req;
        req.userName = j.at("username").get<std::string>();
        req.password = j.at("password").get<std::string>();
        req.email = j.at("email").get<std::string>();

        return req;
    }
    catch (const std::exception& e)
    {
        throw std::runtime_error("Error parsing signup JSON: " + std::string(e.what()));
    }
}

//rooms related
GetPlayersinRoomRequest JsonRequestPacketDeserializer::deserializeGetPlayersRequest(const Buffer& buffer)
{
	try
	{
		json j = json::parse(buffer.begin(), buffer.end());

		GetPlayersinRoomRequest req;
		req.roomld = j.at("roomId").get<unsigned int>();

		return req;
	}
	catch (const std::exception& e)
	{
		throw std::runtime_error("Error parsing GetPlayersinRoomRequest JSON: " + std::string(e.what()));
	}
}

JoinRoomRequest JsonRequestPacketDeserializer::deserializeJoinRoomRequest(const Buffer& buffer)
{
	try
	{
		json j = json::parse(buffer.begin(), buffer.end());

		JoinRoomRequest req;
		req.roomld = j.at("roomId").get<unsigned int>();

		return req;
	}
	catch (const std::exception& e)
	{
		throw std::runtime_error("Error parsing JoinRoomRequest JSON: " + std::string(e.what()));
	}
}

CreateRoomRequest JsonRequestPacketDeserializer::deserializeCreateRoomRequest(const Buffer& buffer)
{
	try
	{
		json j = json::parse(buffer.begin(), buffer.end());

		CreateRoomRequest req;
		req.roomName = j.at("roomName").get <std::string> ();
		req.maxUsers = j.at("maxUsers").get <unsigned int> ();
		req.questionCount = j.at("questionCount").get <unsigned int> ();
		req.answerTimeout = j.at("answerTimeout").get <unsigned int> ();

		return req;
	}
	catch (const std::exception& e)
	{
		throw std::runtime_error("Error parsing CreateRoomRequest JSON: " + std::string(e.what()));
	}
}