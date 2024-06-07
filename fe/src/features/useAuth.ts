import { useMutation } from "react-query";
import { LoginBody, LoginResponse, RegisterBody } from "../types/Identity";
import { fetchAbstract } from "../utils/fetchAbstract";

export const useSignIn = () => {
  return useMutation((data: LoginBody) => {
    return fetchAbstract(
      "Identity/login",
      "post",
      data,
    ) as Promise<LoginResponse>;
  });
};

export const useSignUp = () => {
  return useMutation((data: RegisterBody) => {
    return fetchAbstract("Identity/register", "post", data);
  });
};
