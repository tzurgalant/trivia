#include "JsonResponsePacketSerializer.h"
#include "json.hpp"         



using json = nlohmann::json;

Buffer JsonResponsePacketSerializer::serializeResponse(LoginResponse req)
{
    Buffer b;
    
}

Buffer JsonResponsePacketSerializer::serializeResponse(SignupResponse req)
{

}
