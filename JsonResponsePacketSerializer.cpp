#include "JsonResponsePacketSerializer.h"
#include "json.hpp"         



using json = nlohmann::json;

LoginRequest JsonResponsePacketSerializer::serializeLoginRequest(const Buffer& buffer) {
    try {
        // convert the buffer to strtuct that easy to work whit it 
        auto j = json::parse(buffer.begin(), buffer.end());

        LoginRequest req;
        req.userName = j["username"];
        req.password = j["password"];
        return req;
    }
    catch (const std::exception& e) {
        throw std::runtime_error("Failed to parse JSON: " + std::string(e.what()));
    }
}

SignupRequest JsonResponsePacketSerializer::serializeSignupRequest(const Buffer& buffer)
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
        throw std::runtime_error("Error parsing Signup JSON: " + std::string(e.what()));
    }
}