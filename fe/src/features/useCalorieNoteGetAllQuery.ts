import { useQuery } from "react-query";
import { fetchAbstract } from "../utils/fetchAbstract";

import { CalorieNote } from "../types/CalorieNote";
import { urlBuilder } from "../utils/urlBuilder";

export const useCalorieNoteGetAllQuery = (filter: {
  userId?: string;
  createdAt?: string;
  id?: string;
}) => {
  return useQuery({
    queryKey: ["calories-note", filter],
    queryFn: async () => {
      const cal = await fetchAbstract(
        urlBuilder("CalorieNotes", filter),
        "GET",
      );
      const call = Array.isArray(cal) ? cal : ([cal] as CalorieNote[]);
      const callFil = call
        .filter((c) => {
          if (!filter.userId) return true;
          return c.userId === filter.userId;
        })
        .filter((c) => {
          if (!filter.createdAt) return true;
          return c.createdAt.split("T")[0] === filter.createdAt;
        });

      return callFil.map((c) => ({
        ...c,
      })) as CalorieNote[];
    },
  });
};
