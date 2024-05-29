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
    if (filter.type === "edit") {
      return fetchAbstract("Users/" + filter.data.id, "PUT", data);
    }

    return fetchAbstract("Users/", "POST", data);
  });
};
