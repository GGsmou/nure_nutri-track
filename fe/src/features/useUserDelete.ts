import { useMutation } from "react-query";
import { fetchAbstract } from "../utils/fetchAbstract";

export const useUserDelete = () => {
  return useMutation((data: { id: number }) => {
    return fetchAbstract("Users/" + data.id, "DELETE");
  });
};
