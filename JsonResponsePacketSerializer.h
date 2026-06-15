#pragma once
#include <iostream>

#include "IRequestHandler.h"


class JsonResponsePacketSerializer
{
public:
	static Buffer serializeResponse(LoginResponse res);
	static Buffer serializeResponse(SignupResponse res);
	static Buffer serializeResponse(ErrorResponse res);
	static Buffer serializeResponse(LogoutResponse res);
	static Buffer serializeResponse(GetRoomsResponse res);
	static Buffer serializeResponse(GetPlayersInRoomResponse res);
	static Buffer serializeResponse(JoinRoomResponse res);
	static Buffer serializeResponse(CreateRoomResponse res);
	static Buffer serializeResponse(GetHighScoreResponse res);
	static Buffer serializeResponse(GetPersonalStatsReponse res);
    static Buffer serializeResponse(CloseRoomResponse res);
    static Buffer serializeResponse(StartGameResponse res);
    static Buffer serializeResponse(LeaveRoomResponse res);
    static Buffer serializeResponse(GetRoomStateResponse res);

	static Buffer serializeResponse(const GetGameResultsResponse& response);
	static Buffer serializeResponse(const SubmitAnswerResponse& response);
	static Buffer serializeResponse(const GetQuestionResponse& response);
	static Buffer serializeResponse(const LeaveGameResponse& response);
private:
};