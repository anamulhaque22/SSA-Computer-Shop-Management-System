"use client";
import React, { useState } from "react";

const ForgetPassword = () => {
  const [email, setEmail] = useState("");
  return (
    <div className="container flex justify-center items-center h-[70vh] bg-white">
      <div className="py-5 shadow-md border rounded-md w-[424px] bg-white">
        <div className="border-b flex justify-center ">
          <h3 className="text-xl font-semibold border-b-2 border-b-[#FA8232] text-center inline-block mb-4 pb-1">
            Forget Password
          </h3>
        </div>
        <form className="px-5">
          <div className="form-control w-full">
            <label className="label">
              <span
                className={"font-causten-semi-bold text-base text-[#3C4242]"}
              >
                Email Address
              </span>
            </label>
            <input
              name="email"
              type="email"
              value={email}
              placeholder="Email"
              onChange={(e) => setEmail(e.target.value)}
              className="input  input-bordered w-full focus:outline-none "
            />
          </div>
          <button type="submit" className="uppercase cbtn w-full mt-4 py-2">
            Send Code
          </button>
        </form>
      </div>
    </div>
  );
};

export default ForgetPassword;
