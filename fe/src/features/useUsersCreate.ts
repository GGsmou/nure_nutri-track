import { useMutation } from "react-query";
import { fetchAbstract } from "../utils/fetchAbstract";
import { UserType } from "../types/User";

export const useUsersCreate = (
  filter:
    | {
        type: "edit";
        data: { id: string };
      }
    | {
        type: "create";
      },
) => {
  return useMutation((data: UserType) => {
    const type = filter.type === "edit" ? "PUT" : "POST";
    return fetchAbstract("UserTypes/", type, data);
  });
};
