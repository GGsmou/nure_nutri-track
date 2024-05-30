import { useQuery } from "react-query";
import { fetchAbstract } from "../utils/fetchAbstract";

import { urlBuilder } from "../utils/urlBuilder";
import { WaterNote } from "../types/WaterNote";

export const useWaterNoteGetAllQuery = (filter: {
  userId?: string;
  createdAt?: string;
  id?: string;
}) => {
  return useQuery({
    queryKey: ["water-note", filter],
    queryFn: async () => {
      const w = await fetchAbstract(urlBuilder("WaterNote", filter), "GET");
      const ww = Array.isArray(w) ? w : ([w] as WaterNote[]);

      return ww
        .filter((w) => {
          if (!filter.userId) return true;
          return w.userId === filter.userId;
        })
        .filter((w) => {
          if (!filter.createdAt) return true;
          return w.createdAt === filter.createdAt;
        }) as WaterNote[];
    },
  });
};
