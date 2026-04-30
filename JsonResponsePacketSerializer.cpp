#include "JsonResponsePacketSerializer.h"
#include "json.hpp" // ספריית nlohmann/json
#include <vector>
#include <string>

using json = nlohmann::json;

std::vector<unsigned char> JsonResponsePacketSerializer::serializeResponse(LoginResponse res)
{
    json j;
    j["status"] = res.status;

    std::string jsonStr = j.dump();

    Buffer buffer;

    //msg code
    buffer.push_back(101);

    unsigned int length = jsonStr.length();

    //פירוק ל4 בייטים
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