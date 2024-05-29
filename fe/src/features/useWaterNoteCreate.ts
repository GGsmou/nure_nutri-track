import { useMutation } from "react-query";
import { fetchAbstract } from "../utils/fetchAbstract";
import { WaterNote } from "../types/WaterNote";

export const useWaterNoteCreate = (
  filter:
    | {
        type: "edit";
        data: { id: string };
      }
    | {
        type: "create";
      },
) => {
  return useMutation((data: WaterNote) => {
    if (filter.type === "edit") {
      return fetchAbstract("WaterNote/" + filter.data.id, "PUT", data);
    }

    return fetchAbstract("WaterNote/", "POST", data);
  });
};
