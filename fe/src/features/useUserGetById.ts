import { useQuery } from "react-query";
import { User } from "../types/User";
import { fetchAbstract } from "../utils/fetchAbstract";
import { urlBuilder } from "../utils/urlBuilder";

export const useUserGetById = (id: string) => {
  return useQuery({
    queryFn: async () => {
      return fetchAbstract(
        urlBuilder("users", { id }, true),
        "GET",
      ) as Promise<User>;
    },
    cacheTime: 0,
  });
};
