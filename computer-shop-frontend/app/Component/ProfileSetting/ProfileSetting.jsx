"use client";
import React, { useState } from "react";

const ProfileSetting = () => {
  const [name, setName] = useState("");
  const [currentPassword, setCurrentPassword] = useState("");
  const [newPassword, setNewPassword] = useState("");
  const [confirmPassword, setConfirmPassword] = useState("");
  return (
    <div className="container h-[70vh] flex items-center justify-center">
      <div className="flex w-[900px] justify-center gap-5">
        <div className="border p-5">
          <form action="">
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
                value={name}
                onChange={(e) => setName(e.target.value)}
                className="input  input-bordered w-full focus:outline-none "
              />
            </div>
            <button type="submit" className="uppercase cbtn w-full mt-4 py-2">
              Save Changes
            </button>
          </form>
        </div>
        <div className="border p-5">
          <h3 className="text-xl text-center">Change Password</h3>
          <form action="">
            <div className="form-control w-full">
              <label className="label">
                <span
                  className={"font-causten-semi-bold text-base text-[#3C4242]"}
                >
                  Current Password
                </span>
              </label>
              <input
                name="currentpassword"
                type="password"
                value={currentPassword}
                onChange={(e) => setCurrentPassword(e.target.value)}
                className="input  input-bordered w-full focus:outline-none "
              />
            </div>
            <div className="form-control w-full">
              <label className="label">
                <span
                  className={"font-causten-semi-bold text-base text-[#3C4242]"}
                >
                  New Password
                </span>
              </label>
              <input
                name="newpassword"
                type="password"
                value={newPassword}
                onChange={(e) => setNewPassword(e.target.value)}
                className="input  input-bordered w-full focus:outline-none "
              />
            </div>
            <div className="form-control w-full">
              <label className="label">
                <span
                  className={"font-causten-semi-bold text-base text-[#3C4242]"}
                >
                  Confirm Password
                </span>
              </label>
              <input
                type="password"
                value={confirmPassword}
                onChange={(e) => setConfirmPassword(e.target.value)}
                className="input  input-bordered w-full focus:outline-none "
              />
            </div>
            <button type="submit" className="uppercase cbtn w-full mt-4 py-2">
              Change Password
            </button>
          </form>
        </div>
      </div>
    </div>
  );
};

export default ProfileSetting;
