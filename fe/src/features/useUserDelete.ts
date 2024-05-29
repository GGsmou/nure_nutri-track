import { useMutation } from "react-query";
import { fetchAbstract } from "../utils/fetchAbstract";

export const useUserDelete = () => {
  return useMutation((data: { id: number }) => {
    return fetchAbstract("UserTypes/" + data.id, "DELETE");
  });
};
