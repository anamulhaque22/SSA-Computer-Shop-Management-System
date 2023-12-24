"use client";
import Link from "next/link";
import React, { useState } from "react";

const Registration = () => {
  const REG_OBJ = {
    name: "",
    email: "",
    password: "",
  };
  const [user, setUser] = useState(REG_OBJ);
  const updateInputValue = (e) => {
    const { name, value } = e.target;
    setUser({ ...user, [name]: value });
  };
  return (
    <div className="container flex justify-center items-center h-[70vh] bg-white">
      <div className="py-5 shadow-md border rounded-md w-[424px] bg-white">
        <div className="border-b flex justify-center ">
          <h3 className="text-xl font-semibold border-b-2 border-b-[#FA8232] text-center inline-block mb-4 pb-1">
            Sign Up
          </h3>
        </div>
        <form className="px-5">
          <div className="form-control w-full">
            <label className="label">
              <span
                className={"font-causten-semi-bold text-base text-[#3C4242]"}
              >
                Full Name
              </span>
            </label>
            <input
              name="name"
              type="text"
              value={user.name}
              placeholder="Full Name"
              onChange={updateInputValue}
              className="input  input-bordered w-full focus:outline-none "
            />
          </div>
          <div className="form-control w-full">
            <label className="label">
              <span
                className={"font-causten-semi-bold text-base text-[#3C4242]"}
              >
                Email
              </span>
            </label>
            <input
              name="email"
              type="email"
              value={user.email}
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
                Password
              </span>
            </label>
            <input
              name="password"
              type="password"
              value={user.password}
              placeholder="First Name"
              onChange={updateInputValue}
              className="input  input-bordered w-full focus:outline-none "
            />
          </div>
          <button type="submit" className="uppercase cbtn w-full mt-4 py-2">
            Sign IN
          </button>
        </form>
        <div className="text-center mt-4">
          <p>
            Have already an account?{" "}
            <Link href={"/login"} className="text-[#FA8232]">
              Login Here
            </Link>
          </p>
        </div>
      </div>
    </div>
  );
};

export default Registration;
