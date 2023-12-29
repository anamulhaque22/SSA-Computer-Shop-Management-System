"use client";
import Link from "next/link";
import React, { useState } from "react";

const Login = () => {
  const LOGIN_OBJ = {
    email: "",
    password: "",
  };
  const updateInputValue = (e) => {
    const { name, value } = e.target;
    setLoginInfo({ ...loginInfo, [name]: value });
  };
  const [loginInfo, setLoginInfo] = useState(LOGIN_OBJ);
  return (
    <div className="container flex justify-center items-center h-[70vh]">
      <div className="py-5 shadow-md border rounded-md">
        <div className="border-b flex justify-center ">
          <h3 className="text-xl font-semibold border-b-2 border-b-[#FA8232] text-center inline-block mb-4 pb-1">
            Sign In
          </h3>
        </div>
        <form className="px-5">
          <div className="form-control w-full">
            <label className="label">
              <span
                className={"font-causten-semi-bold text-base text-[#3C4242]"}
              >
                First Name
              </span>
            </label>
            <input
              name="email"
              type="email"
              value={loginInfo.email}
              placeholder="First Name"
              onChange={updateInputValue}
              className="input  input-bordered w-full focus:outline-none "
            />
          </div>
          <div className="form-control w-full">
            <label className="label">
              <span
                className={"font-causten-semi-bold text-base text-[#3C4242]"}
              >
                First Name
              </span>
            </label>
            <input
              name="password"
              type="password"
              value={loginInfo.password}
              placeholder="First Name"
              onChange={updateInputValue}
              className="input  input-bordered w-full focus:outline-none "
            />
          </div>
          <Link href={"/forget-password"} className="text-[#FA8232]">
            Forget Password?
          </Link>
          <button type="submit" className="uppercase cbtn w-full mt-4 py-2">
            Sign IN
          </button>
        </form>
        <div className="text-center mt-4">
          <p>
            Don{"'"}t have account?{" "}
            <Link href={"/register"} className="text-[#FA8232]">
              Signup Now
            </Link>
          </p>
        </div>
      </div>
    </div>
  );
};

export default Login;
