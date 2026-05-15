#pragma once
#include <iostream>
//interface
class IDatabase
{
public:
	virtual bool open() = 0;
	virtual bool close() = 0;

	//user related
	virtual int doesUserExist(std::string name) = 0;
	virtual int doesPasswordMatch(std::string userName, std::string password) = 0;
	virtual int addNewUser(std::string name, std::string pass, std::string email) = 0;

	//question related
	virtual std::list<Question> getQuestions() = 0;

};